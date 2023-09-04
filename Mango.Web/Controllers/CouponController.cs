﻿using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDTO>? couponDTOs = new ();

            ResponseDTO? response = await _couponService.GetAllCoupons();
            if (response!.Result != null && response.IsSuccess) 
            {
                couponDTOs = JsonConvert.DeserializeObject<List<CouponDTO>>(Convert.ToString(response.Result)!);
            }

            return View(couponDTOs);
        }

        public async Task<IActionResult> CreateCoupon() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CouponDTO coupon)
        {
            if (ModelState.IsValid) 
            {
                ResponseDTO? response = await _couponService.CreateCoupon(coupon);
                if (response!.Result != null && response.IsSuccess)
                {
                    return RedirectToAction("CouponIndex");
                }
            }
            return View(coupon);
        }
    }
}