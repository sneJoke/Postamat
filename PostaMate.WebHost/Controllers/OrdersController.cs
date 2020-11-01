using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostaMate.Core.Domain;
using PostaMate.DataAccess.Repositories;
using PostaMate.WebHost.Models;

namespace PostaMate.WebHost.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly InMemoryOrderRepository _orderRepository;
        private readonly InMemoryPostamatRepository _postamatRepository;

        public OrdersController(InMemoryOrderRepository orderRepository, InMemoryPostamatRepository postamatRepository)
        {
            _orderRepository = orderRepository;
            _postamatRepository = postamatRepository;
        }
        
        [HttpGet("{num}")]
        public async Task<ActionResult<OrderResponse>> GetOrderByIdAsync(int num)
        {
            var order = await _orderRepository.GetByIdAsync(num);

            if (order == null) return NotFound();

            OrderResponse response = new OrderResponse(order);
            
            return response;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync(CreateOrderResponse response)
        {
            Match match = Regex.Match(response.PhoneNumber, @"^\+7\d{3}-\d{3}-\d{2}-\d{2}$");
            if (!match.Success) return BadRequest();

            if (response.Blocks.Count() > 10) return BadRequest();

            var postamat = await _postamatRepository.GetByIdAsync(response.PostamatNumber.ToString());
            if (postamat == null) return NotFound();
            if (postamat.Status == false) return Forbid();

            Order order = new Order
            {
                Number = response.Number,
                Blocks = response.Blocks,
                Cost = response.Cost,
                PhoneNumber = response.PhoneNumber,
                PostamatNumber = response.PostamatNumber,
                Recipient = response.Recipient,
                StatusOrder = Core.Types.StatusOrder.Registered,
            };

            await _orderRepository.CreateAsync(order);

            return Ok();
        }

        [HttpPost("{num}/cancelOrder")]
        public async Task<IActionResult> CancelOrderAsync(int num)
        {
            var order = await _orderRepository.GetByIdAsync(num);
            if (order == null) return NotFound();

            await _orderRepository.CancelAsync(num);
            
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderAsync(UpdateOrderResponse response)
        {
            Match match = Regex.Match(response.PhoneNumber, @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}");
            if (!match.Success) return BadRequest();

            if (response.Blocks.Count() > 10) return BadRequest();

            var order = await _orderRepository.GetByIdAsync(response.Number);
            if (order == null) return NotFound();

            order.Number = response.Number;
            order.Blocks = response.Blocks;
            order.Cost = response.Cost;
            order.PhoneNumber = response.PhoneNumber;
            order.Recipient = response.Recipient;

            await _orderRepository.UpdateAsync(order);

            return Ok();
        }

    }
}