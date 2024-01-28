using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NuGet.Protocol.Plugins;
using WebApp_API.Model;
using WebApp_API.Repository.IRipository;

namespace WebApp_API.Controllers
{
    public class NationalParkController : Controller
    {
        private readonly INationalParkRepository _nationalparkRepository;
        public NationalParkController( INationalParkRepository nationalParkRepository)
        {
            _nationalparkRepository = nationalParkRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region APIs
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {   
            return Json(new { data = await _nationalparkRepository.GetAllAsync(SD.NationalParkAPIPath) });
        }  
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _nationalparkRepository.DeleteAsync(SD.NationalParkAPIPath, id);
            if (status) return Json(new { succes = true, Message = "Data deleted !" });
              return Json(new { succes = false, Message = "Something went wrog while deleting data" });
          
            
        }
 

        #endregion
       
        //error async me hai

        public async Task<IActionResult> Upsert(int? id)
        {
            NationalPark nationalPark = new NationalPark();
            if (id == null) return View(nationalPark);
            nationalPark = await _nationalparkRepository.GetAsync(SD.NationalParkAPIPath, id.GetValueOrDefault());
            if (nationalPark == null) return NotFound();
            return View(nationalPark);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(NationalPark nationalPark)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    nationalPark.Picture = p1;

                }
                else
                {
                    var nationalParkInDb = await _nationalparkRepository.GetAsync
                        (SD.NationalParkAPIPath, nationalPark.Id);
                    nationalPark.Picture = nationalParkInDb.Picture;
                }
                if (nationalPark.Id == 0)

                    await _nationalparkRepository.CreateAsync(SD.NationalParkAPIPath, nationalPark);
                else
                    await _nationalparkRepository.UpdateAsync(SD.NationalParkAPIPath, nationalPark);
                return RedirectToAction("Index");

            }
            else
            {
                return View(nationalPark);
            }
        }




    }
}
