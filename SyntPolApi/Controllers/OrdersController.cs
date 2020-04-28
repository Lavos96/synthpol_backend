using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SyntPolApi.Core.DTOs;
using SyntPolApi.Core.Models;
using SyntPolApi.Core.Services;
using SyntPolApi.DAL;
using SyntPolApi.Infrastructure;

namespace SyntPolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IProductService productService;
        private readonly IOrderItemService orderItemService;
        private readonly IInvoiceService invoiceService;
        private readonly IInvoiceEdiService invoiceEdiService;
        private readonly IMapper mapper;

        public OrdersController(IOrderService orderService, IMapper mapper, IProductService productService, 
            IOrderItemService orderItemService, IInvoiceService invoiceService, IInvoiceEdiService invoiceEdiService)
        {
            this.orderService = orderService;
            this.mapper = mapper;
            this.productService = productService;
            this.orderItemService = orderItemService;
            this.invoiceService = invoiceService;
            this.invoiceEdiService = invoiceEdiService;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await orderService.GetAsync();
            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderWithProducts(int id)
        {
            var order = await orderService.GetWithProductsAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            var mappedOrder = mapper.Map<Order, GetOrderDTO>(order);
            return Ok(mappedOrder);
        }

        // GET: api/Orders
        [HttpGet("withProducts")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersWithProducts()
        {
            var orders = await orderService.GetOrdersWithProductsAsync();
            if (orders == null)
            {
                return NotFound();
            }

            var mappedOrders = mapper.Map<IEnumerable<Order>, IEnumerable<GetOrderDTO>>(orders);
            return Ok(mappedOrders);
        }

        // GET: api/Orders
        [HttpGet("user/{username}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersWithProductsByUsername(string username)
        {
            var orders = await orderService.GetAllOrdersWithProductsByUsername(username);
            if (orders == null)
            {
                return NotFound();
            }

            var mappedOrders = mapper.Map<IEnumerable<Order>, IEnumerable<GetOrderDTO>>(orders);
            return Ok(mappedOrders);
        }

        //    // PUT: api/Orders/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //    // more details see https://aka.ms/RazorPagesCRUD.
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutOrder(int id, Order order)
        //    {
        //        if (id != order.OrderId)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(order).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!OrderExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        // POST: api/Orders
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder([FromBody] PostOrderDTO order)
        {
            var orderToAdd = new Order
            {
                SellDate = DateTime.Now,
                ShallDisplay = true,
                OrderState = OrderState.New,
                InvoiceId = null,
                OrderValue = 0.0M,
                Username = order.Invoice.Username
            };

            List<Product> products = new List<Product>();

            foreach (var item in order.PostOrders)
            {
                var product = await productService.GetByIdAsync(item.ProductId);
                products.Add(product);
                orderToAdd.OrderValue += (product.NettoPrice + decimal.Divide(product.VAT, 100) * product.NettoPrice) * item.QuantityOfProducts;
            }

            var placedOrder = await orderService.CreateOrder(orderToAdd);

            var orderItems = new List<OrderItem>();
            foreach (var product in products)
            {
                var orderItem = new OrderItem
                {
                    OrderId = placedOrder.OrderId,
                    ProductId = product.ProductId
                };
                foreach (var item in order.PostOrders)
                {
                    if(item.ProductId == product.ProductId)
                    {
                        orderItem.Amount = item.QuantityOfProducts;
                        orderItem.NettoPrice = product.NettoPrice * item.QuantityOfProducts;
                        orderItem.BruttoPrice += (product.NettoPrice + decimal.Divide(product.VAT, 100) * product.NettoPrice) * item.QuantityOfProducts;
                    }
                }
                await orderItemService.CreateOrderItem(orderItem);
                orderItems.Add(orderItem);
            }

            EdiParser ediParser = new EdiParser();

            var invoice = await CreateInvoice(placedOrder.OrderId, order.Invoice);
            var invoiceEdiToAdd = new InvoiceEdi
            {
                Username = invoice.Username,
                InvoiceId = invoice.InvoiceId,
                EdiString = ediParser.Save(invoice.InvoiceId.ToString(), invoice.IssueDate.ToString(), invoice.DeliveryDate.ToString(), SynthPolInfo.supplierName, SynthPolInfo.supplierStreet, SynthPolInfo.supplierZipCode, SynthPolInfo.supplierCity, SynthPolInfo.supplierNIP, invoice.Name, invoice.Street, invoice.ZipCode, invoice.City, invoice.NIP, orderItems)
            };

            var invoiceEdi = await invoiceEdiService.CreateInvoiceEdi(invoiceEdiToAdd);

            var newOrder = placedOrder;
            newOrder.InvoiceId = invoice.InvoiceId;
            await orderService.UpdateOrder(placedOrder, newOrder);

            var newInvoice = invoice;
            newInvoice.InvoiceEdiId = invoiceEdi.InvoiceEdiId;
            await invoiceService.UpdateInvoice(invoice, newInvoice);

            return Ok();
        }

        //TODO: delete orders (chyba bedzie zmienial orderState na completed)

        //// DELETE: api/Orders/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Order>> DeleteOrder(int id)
        //{
        //    var order = await _context.Orders.FindAsync(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Orders.Remove(order);
        //    await _context.SaveChangesAsync();

        //    return order;
        //}

        public async Task<Invoice> CreateInvoice(int orderId, PostInvoiceDTO invoice)
        {
            var invoiceToAdd = mapper.Map<PostInvoiceDTO, Invoice>(invoice);
            if(string.IsNullOrWhiteSpace(invoiceToAdd.NIP))
            {
                invoiceToAdd.NIP = "1234567890";
            }
            invoiceToAdd.IssueDate = DateTime.Now;
            invoiceToAdd.DeliveryDate = DateTime.Now;
            invoiceToAdd.OrderId = orderId;
            invoiceToAdd.Username = invoice.Username;
            invoiceToAdd.ShallDisplay = true;
            var addedInvoice = await invoiceService.CreateInvoice(invoiceToAdd);
            return addedInvoice;
        }
    }
}
