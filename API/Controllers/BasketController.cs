using System.Threading.Tasks;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Entity;
using Microsoft.EntityFrameworkCore;
using API.ErrorResponse;
using System;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using API.Dto;
using System.Linq;

namespace API.Controllers
{
    public class BasketController : BaseController
    {
        private readonly StoreContext _context;
        private readonly IMapper _mapper;

        public BasketController(StoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<BasketDto>> GetBasket()
        {
            var basket = await ExtractBasket();

            if (basket == null) return NotFound(new ApiResponse(404));

            var basketResponse = _mapper.Map<Basket, BasketDto>(basket);
            return Ok(basketResponse);
        }

        [HttpPost]
        public async Task<ActionResult<BasketDto>> AddItemToBasket(Guid courseId) // /api/Basket?courseId=
        {
            var basket = await ExtractBasket();

            if (basket == null) basket = CreateBasket();
            var course = await _context.Courses.FindAsync(courseId);

            if (course == null) return NotFound(new ApiResponse(404));
            basket.AddCourseItem(course);

            var result = await _context.SaveChangesAsync() > 0;
            var basketResponse = _mapper.Map<Basket, BasketDto>(basket);

            if (result) return basketResponse;
            return BadRequest(new ApiResponse(400, "Problem saving item to the basket"));
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveBasketItem(Guid courseId)
        {
            var basket = await ExtractBasket();

            if (basket == null) return NotFound(new ApiResponse(404));
            basket.RemoveCourse(courseId);

            var result = await _context.SaveChangesAsync() > 0;

            if (result) return Ok();
            return BadRequest(new ApiResponse(400, "Problem removing item from the basket"));
        }

        private Basket CreateBasket()
        {
            var clientId = Guid.NewGuid().ToString();
            var options = new CookieOptions { IsEssential = true, Expires = DateTime.Now.AddDays(10) };
            Response.Cookies.Append("clientId", clientId, options);
            var basket = new Basket { ClientId = clientId };
            _context.Baskets.Add(basket);
            return basket;
        }

        private async Task<Basket> ExtractBasket()
        {
            var basket = await _context.Baskets
                .Include(b => b.Items)
                .ThenInclude(i => i.Course)
                .OrderBy(i => i.Id)
                .FirstOrDefaultAsync(x => x.ClientId == Request.Cookies["clientId"]);

            if (basket == null) return null;
            return basket;
        }
    }
}