using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Shop.Coupons.Database;
using Service.Shop.Coupons.DTO;
using Service.Shop.Coupons.Model;
using System.Linq;

namespace Service.Shop.Coupons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly DatabaseContext _db;
        private ResponseDTO _response;
        private IMapper _mapper;
        public CouponAPIController(DatabaseContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDTO();
            _mapper = mapper;
        }
        // Get all the record from the database 
        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                IEnumerable<CouponModel> objList = _db.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDTO>>(objList);
            } catch (Exception ex)
            {
                _response.IsSuccessful = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        //Get a single record from the database
        [HttpGet]
        [Route("{id:int}")]
        public ResponseDTO Get(int id)
        {
            try
            {
                CouponModel obj = _db.Coupons.First(u => u.CouponId == id);
                _response.Result = _mapper.Map<CouponDTO>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccessful = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        //Get a record by the coupon code 
        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDTO GetByCode(string code)
        { 
            try
            {
                CouponModel obj = _db.Coupons.First(u => u.CouponCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CouponDTO>(obj);
                if(obj == null)
                {
                    _response.IsSuccessful = false;
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccessful = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPost]
       public ResponseDTO Post([FromBody] CouponDTO couponDTO)
        {
            try
            {
                CouponModel obj = _mapper.Map<CouponModel>(couponDTO);
                _db.Coupons.Add(obj);

                _response.Result = _mapper.Map<CouponDTO>(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccessful = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPut]
        public ResponseDTO Update([FromBody] CouponDTO couponDTO)
        {
            try
            {
                CouponModel obj = _mapper.Map<CouponModel>(couponDTO);
                _db.Coupons.Update(obj);
                if(couponDTO == null)
                {
                    _response.IsSuccessful = false;
                }

                _response.Result = _mapper.Map<CouponDTO>(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccessful = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpDelete]
        public ResponseDTO Delete(int id)
        {
            try
            {
                CouponModel obj = _db.Coupons.First(u =>u.CouponId == id);
                _db.Coupons.Remove(obj);

                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccessful = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }

}
