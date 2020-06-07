using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINAL.Data;
using FINAL.Injections;
using FINAL.Models;
using FINAL.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace FINAL.Controllers
{
    public class AddController : BaseController
    {
        private readonly PropDbContext _context;
        private readonly IAuth _auth;
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _hosting;
        public AddController(PropDbContext context, Microsoft.AspNetCore.Hosting.IWebHostEnvironment hosting, IAuth auth) : base(context)
        {
            _context = context;
            _auth = auth;
            _hosting = hosting;
        }
      
        

        public IActionResult Index()
        {
            AddViewModel data = new AddViewModel
            {
                FilterPanel = new FilterPanelViewModel
                {
                    AddTypes = _context.AddTypes.ToList(),
                    Cities = _context.Cities.ToList(),
                    PropertySorts = _context.PropertySorts.ToList(),
                },
                AddsPanel = new AddsPanelViewModel
                {
                    Type = ViewType.small,
                    AddList = _context.Addvertisiments.Include("AddType").
                                                                        Include("Property").
                                                                            Include("Property.City").
                                                                                Include("Property.District").
                                                                                    Include("Property.Flat").
                                                                                        Include("Property.Floor").
                                                                                            Include("Property.PropDoc").
                                                                                                Include("Property.PropertySort").
                                                                                                    Include("Property.Project").
                                                                                                         Where(a => a.User.Status == UserStatus.Active && a.AddStatus == AddStatus.Active).OrderByDescending(a=>a.CreatedAt).ToList(),
                },
                  Breadcumb = new BreadcumbViewModel
                  {
                      Title = "Elanlar",
                      Path = new List<BreadcumbItemViewModel>()
                  },
            };
            BreadcumbItemViewModel home = new BreadcumbItemViewModel
            {
                Name = "Ana səhifə",
                Controller = "Home",
                Action = "index"
            };

            BreadcumbItemViewModel adds = new BreadcumbItemViewModel
            {
                Name = "Bütün elanlar"
            };

            data.Breadcumb.Path.Add(home);
            data.Breadcumb.Path.Add(adds);

            ViewBag.Partial = data.Breadcumb;
            ViewBag.Filters = data.FilterPanel;
            ViewBag.Adds = data.AddsPanel;
            ViewBag.AddsCount = data.AddsPanel.AddList.Count();
            return View(data);
        }

        public IActionResult Sale(int id)
        {
            PropertySort propertySort = _context.PropertySorts.Where(ps => ps.PropertySortId == id).FirstOrDefault();

            if (propertySort != null)
            {
                AddViewModel data = new AddViewModel
                {
                    FilterPanel = new FilterPanelViewModel
                    {
                        AddTypes = _context.AddTypes.ToList(),
                        Cities = _context.Cities.ToList(),
                        PropertySorts = _context.PropertySorts.ToList(),
                    },
                    AddsPanel = new AddsPanelViewModel
                    {
                        Type = ViewType.small,
                        AddList = _context.Addvertisiments.Include("AddType").
                                                                       Include("Property").
                                                                           Include("Property.City").
                                                                               Include("Property.District").
                                                                                   Include("Property.Flat").
                                                                                       Include("Property.Floor").
                                                                                           Include("Property.PropDoc").
                                                                                               Include("Property.PropertySort").
                                                                                                   Include("Property.Project").
                                                                                                        Where(a => a.AddTypeID > 2 && a.User.Status == UserStatus.Active && a.AddStatus == AddStatus.Active && a.Property.PropertySortId == id).OrderByDescending(a => a.CreatedAt).ToList(),
                    },
                    Breadcumb = new BreadcumbViewModel
                    {
                        Title = "Satış elanları",
                        Path = new List<BreadcumbItemViewModel>()
                    },
                };
                BreadcumbItemViewModel home = new BreadcumbItemViewModel
                {
                    Name = "Ana səhifə",
                    Controller = "Home",
                    Action = "index"
                };

                BreadcumbItemViewModel adds = new BreadcumbItemViewModel
                {
                    Name = "Bütün elanlar",
                    Controller = "Add",
                    Action = "index"
                };
                BreadcumbItemViewModel finded = new BreadcumbItemViewModel
                {
                    Name = propertySort.PropertySortName,
                };

                data.Breadcumb.Path.Add(home);
                data.Breadcumb.Path.Add(adds);
                data.Breadcumb.Path.Add(finded);
                ViewBag.Partial = data.Breadcumb;
                ViewBag.Filters = data.FilterPanel;
                ViewBag.Adds = data.AddsPanel;
                ViewBag.AddsCount = data.AddsPanel.AddList.Count();
                return View(data);
            }
            else
            {
                return BadRequest();
            }

        }

        public IActionResult Rent(int id)
        {
            PropertySort propertySort = _context.PropertySorts.Where(ps => ps.PropertySortId == id).FirstOrDefault();

            if (propertySort != null)
            {
                AddViewModel data = new AddViewModel
                {
                    FilterPanel = new FilterPanelViewModel
                    {
                        AddTypes = _context.AddTypes.ToList(),
                        Cities = _context.Cities.ToList(),
                        PropertySorts = _context.PropertySorts.ToList(),
                    },
                    AddsPanel = new AddsPanelViewModel
                    {
                        Type = ViewType.small,
                        AddList = _context.Addvertisiments.Include("AddType").
                                                                       Include("Property").
                                                                           Include("Property.City").
                                                                               Include("Property.District").
                                                                                   Include("Property.Flat").
                                                                                       Include("Property.Floor").
                                                                                           Include("Property.PropDoc").
                                                                                               Include("Property.PropertySort").
                                                                                                   Include("Property.Project").
                                                                                                        Where(a => a.AddTypeID < 3 && a.User.Status == UserStatus.Active && a.AddStatus == AddStatus.Active && a.Property.PropertySortId == id).OrderByDescending(a => a.CreatedAt).ToList(),
                    },
                    Breadcumb = new BreadcumbViewModel
                    {
                        Title = "Kirayə elanları",
                        Path = new List<BreadcumbItemViewModel>()
                    },
                };
                BreadcumbItemViewModel home = new BreadcumbItemViewModel
                {
                    Name = "Ana səhifə",
                    Controller = "Home",
                    Action = "index"
                };

                BreadcumbItemViewModel adds = new BreadcumbItemViewModel
                {
                    Name = "Bütün elanlar",
                    Controller = "Add",
                    Action = "index"
                };
                BreadcumbItemViewModel finded = new BreadcumbItemViewModel
                {
                    Name = propertySort.PropertySortName,
                };

                data.Breadcumb.Path.Add(home);
                data.Breadcumb.Path.Add(adds);
                data.Breadcumb.Path.Add(finded);
                ViewBag.Partial = data.Breadcumb;
                ViewBag.Filters = data.FilterPanel;
                ViewBag.Adds = data.AddsPanel;
                ViewBag.AddsCount = data.AddsPanel.AddList.Count();
                return View(data);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet]
        public IActionResult Search(AddSearchGetViewModel SearchGet)
        {

            if (ModelState.IsValid)
            {
                AddViewModel data = new AddViewModel
                {
                    FilterPanel = new FilterPanelViewModel
                    {
                        AddTypes = _context.AddTypes.ToList(),
                        Cities = _context.Cities.ToList(),
                        PropertySorts = _context.PropertySorts.ToList(),
                    },
                    AddsPanel = new AddsPanelViewModel
                    {
                        Type = ViewType.small,
                        AddList = _context.Addvertisiments.Include("AddType").
                                                                        Include("Property").
                                                                            Include("Property.City").
                                                                                Include("Property.District").
                                                                                    Include("Property.Flat").
                                                                                        Include("Property.Floor").
                                                                                            Include("Property.PropDoc").
                                                                                                Include("Property.PropertySort").
                                                                                                    Include("Property.Project").
                                                                                                         Where(a => a.User.Status == UserStatus.Active &&
                                                                                                                    a.AddStatus == AddStatus.Active &&
                                                                                                                   ((SearchGet.AddTypeId == null ? true : a.AddTypeID == SearchGet.AddTypeId) &&
                                                                                                                   (SearchGet.CityId == null ? true : a.Property.CityId == SearchGet.CityId) &&
                                                                                                                   (SearchGet.DistrictId == null ? true : a.Property.DistrictId == SearchGet.DistrictId) &&
                                                                                                                   (SearchGet.PropertySortId == null ? true : a.Property.PropertySortId == SearchGet.PropertySortId))).OrderByDescending(a => a.CreatedAt).ToList(),
                    },
                    Breadcumb = new BreadcumbViewModel
                    {
                        Title = "Axtarılan elanlar",
                        Path = new List<BreadcumbItemViewModel>()
                    },
                };
                BreadcumbItemViewModel home = new BreadcumbItemViewModel
                {
                    Name = "Ana səhifə",
                    Controller = "Home",
                    Action = "index"
                };

                BreadcumbItemViewModel adds = new BreadcumbItemViewModel
                {
                    Name = "Bütün elanlar",
                    Controller = "Add",
                    Action = "index"
                };
                BreadcumbItemViewModel finded = new BreadcumbItemViewModel
                {
                    Name = "Axtarış"
                };
                data.Breadcumb.Path.Add(home);
                data.Breadcumb.Path.Add(adds);
                data.Breadcumb.Path.Add(finded);
                ViewBag.Partial = data.Breadcumb;
                ViewBag.Filters = data.FilterPanel;
                ViewBag.Adds = data.AddsPanel;
                ViewBag.AddsCount = data.AddsPanel.AddList.Count();
                return View(data);

            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult Create()
        {
            var token = Request.Cookies["token"];

            if (token == null)
            {
                return RedirectToAction("index", "account");
            }
            else
            {
                AddViewModel data = new AddViewModel
                {
                    AddCreateIndex = new AddCreateIndexViewModel {
                        Cities = _context.Cities.Include(c => c.Districts).ToList(),
                        PropertySorts = _context.PropertySorts.OrderBy(ps => ps.PropertySortId).ToList(),
                        AddTypes = _context.AddTypes.OrderBy(ad => ad.AddTypeId).ToList(),
                        Flats = _context.Flats.OrderBy(f => f.FlatID).ToList(),
                        Floors = _context.Floors.OrderBy(f => f.FloorID).ToList(),
                        PropDocs = _context.PropDocs.OrderBy(ps => ps.PropDocID).ToList(),
                        Features = _context.Features.OrderBy(f => f.FeatureID).ToList()
                    },
                  
                    Breadcumb = new BreadcumbViewModel
                    
                    {
                        Title = "Elan yerləşdir",
                        Path = new List<BreadcumbItemViewModel>()
                    },
                    
                   
                };
                BreadcumbItemViewModel home = new BreadcumbItemViewModel
                {
                    Name = "Ana səhifə",
                    Controller = "Home",
                    Action = "index"
                };

                BreadcumbItemViewModel create = new BreadcumbItemViewModel
                {
                    Name = "Elan yerləşdirmə"
                };

                data.Breadcumb.Path.Add(home);
                data.Breadcumb.Path.Add(create);

                ViewBag.Partial = data.Breadcumb;


                return View(data);
            }
            
        }
        [HttpPost]
        public IActionResult Create(AddCreatePostViewModel AddCreatePost)
        {

            //Checking User who created addvertisiment
            if (_auth.User.Token != Request.Cookies["token"])
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                Property newProp = new Property //CREATE NEW PROPERTY
                {
                    CityId = AddCreatePost.CityId,
                    DistrictId = AddCreatePost.DistrictId,
                    PropertySortId = AddCreatePost.PropertySortId,
                    PropDocId = AddCreatePost.PropDocId,
                    FloorId = AddCreatePost.FloorId,
                    FloorSum = AddCreatePost.FloorSum,
                    FlatId = AddCreatePost.FlatId,
                    PropProjectId = AddCreatePost.ProjectId,
                    BuildingVolume = AddCreatePost.BuildingVolume,
                    LandVolume = AddCreatePost.LandVolume,
                    Longitude = AddCreatePost.Longitude,
                    Latitude = AddCreatePost.Latitude,
                    FullAbout = AddCreatePost.FullAbout,
                    FullAddress = AddCreatePost.PropertyFullAddress
                };
                
                
                _context.Properties.Add(newProp);
                _context.SaveChanges();

                foreach (Feature item in AddCreatePost.Features) 
                {
                    if (item.Selected)
                    {
                        PropFeature newPropFeature = new PropFeature //PROPERTY FEATURE
                        {
                            PropertyID = newProp.PropertyId,
                            FeatureID = item.FeatureID
                        };

                        _context.PropFeatures.Add(newPropFeature);
                        _context.SaveChanges();
                    }
                }

                string FileName;

                if (AddCreatePost.Photos != null && AddCreatePost.Photos.Count() > 0)
                {
                    
                    foreach (IFormFile photo in AddCreatePost.Photos)
                    {
                        string UploadsFolder;
                        
                        if (AddCreatePost.AddTypeId < 3)
                        {
                            UploadsFolder = Path.Combine(_hosting.WebRootPath, "img", "property", "rent");
                        }
                        else
                        {
                            UploadsFolder = Path.Combine(_hosting.WebRootPath, "img", "property", "sale");
                        } 
                        FileName = Guid.NewGuid() + "_" + photo.FileName;
                        string FilePath = Path.Combine(UploadsFolder, FileName);
                        photo.CopyTo(new FileStream(FilePath, FileMode.Create));

                        PropPhoto newPropPhoto = new PropPhoto //CREATE NEW PHOTO OF PROPERTY
                        {
                            PropPhotoName = FileName,
                            PropertyId = newProp.PropertyId
                        };
                        _context.PropPhotos.Add(newPropPhoto);
                        _context.SaveChanges();
                    }

                }

                Addvertisiment newAdd = new Addvertisiment // CREATE NEW ADDVERTISIMENT
                {
                    PropertyID = newProp.PropertyId,
                    UserId = _auth.User.UserId,
                    AddTypeID = AddCreatePost.AddTypeId,
                    PropPrice = AddCreatePost.AddPrice,
                    CreatedAt = DateTime.Now,
                    ExpDate = DateTime.Now.AddMonths(1),
                    AddStatus = AddStatus.Waiting
                };

                _context.Addvertisiments.Add(newAdd);

                newProp.MainPhoto = newProp.Photos[0].PropPhotoName;
                _context.Entry(newProp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                _context.SaveChanges();
                TempData["Success"] = "Elanınız qəbul edildi, təsdiq edildikdən sonra yayımlanacaq.";
                return RedirectToAction("index", "home");
            }
            else
            {
                AddViewModel data = new AddViewModel
                {
                    AddCreateIndex = new AddCreateIndexViewModel
                    {
                        Cities = _context.Cities.Include(c => c.Districts).ToList(),
                        PropertySorts = _context.PropertySorts.OrderBy(ps => ps.PropertySortId).ToList(),
                        AddTypes = _context.AddTypes.OrderBy(ad => ad.AddTypeId).ToList(),
                        Flats = _context.Flats.OrderBy(f => f.FlatID).ToList(),
                        Floors = _context.Floors.OrderBy(f => f.FloorID).ToList(),
                        PropDocs = _context.PropDocs.OrderBy(ps => ps.PropDocID).ToList(),
                        Features = _context.Features.OrderBy(f => f.FeatureID).ToList()
                    },

                    Breadcumb = new BreadcumbViewModel

                    {
                        Title = "Elan yerləşdir",
                        Path = new List<BreadcumbItemViewModel>()
                    },


                };
                BreadcumbItemViewModel home = new BreadcumbItemViewModel
                {
                    Name = "Ana səhifə",
                    Controller = "Home",
                    Action = "index"
                };

                BreadcumbItemViewModel create = new BreadcumbItemViewModel
                {
                    Name = "Elan yerləşdirmə"
                };

                data.Breadcumb.Path.Add(home);
                data.Breadcumb.Path.Add(create);

                ViewBag.Partial = data.Breadcumb;


                return View(data);

            }


        }
        
        public IActionResult GetProjects(int id)
        {
            List<PropProject> projects = _context.PropProjects.Where(pp => pp.PropertySortId == id).ToList();

            return Ok(
               projects.Select(p => new
               {
                   p.PropProjectID,
                   p.PropProjectName
               }));
        }

        public IActionResult GetDistricts(int id)
        {
            List<District> districts = _context.Districts.Where(d => d.CityID == id).ToList();

            return Ok(
                districts.Select(d => new
                {
                    d.DistrictId,
                    d.DistrictName
                }));
        }

        public IActionResult GetGeoInfo(int id)
        {
            City SelectedCity = _context.Cities.Where(c => c.CityId == id).FirstOrDefault();

            return Ok(
                new
                {
                    SelectedCity.Latitude,
                    SelectedCity.Longitude
                }
                
                );
        }

        public IActionResult Detail(int id)
        {
            Addvertisiment Add = _context.Addvertisiments.Include("AddType").
                                                                        Include("Property").
                                                                            Include("Property.City").
                                                                                Include("Property.District").
                                                                                    Include("Property.Flat").
                                                                                        Include("Property.Floor").
                                                                                            Include("Property.PropDoc").
                                                                                                Include("Property.PropertySort").
                                                                                                    Include("Property.Project").
                                                                                                                Where(a => a.AddvertisimentID == id && a.AddStatus == AddStatus.Active).FirstOrDefault();

            if (Add == null)
            {
                return NotFound();
            }
            else
            {
                AddViewModel data = new AddViewModel
                {
                    AddDetailIndex = new AddDetailIndexViewModel
                    {
                        Add = Add,
                        PropertyPhotos = _context.PropPhotos.Where(pp => pp.PropertyId == Add.PropertyID).ToList(),
                        Features = _context.PropFeatures.Include(pf => pf.Feature).Where(pf => pf.PropertyID == Add.PropertyID).ToList(),

                    },
                    Owner = new OwnerPanelViewModel
                    {
                        Owner = _context.Users.Include(u => u.Adds).Where(u => u.UserId == Add.UserId).FirstOrDefault(),
                        OwnerActiveAdds = _context.Addvertisiments.Where(a => a.UserId == Add.UserId && a.AddStatus == AddStatus.Active).Count()
                    },
                    AddsPanel = new AddsPanelViewModel
                    {
                         Type = ViewType.normal,
                         AddList = _context.Addvertisiments.Include("Property").
                                                                            Include("Property.City").
                                                                                Include("Property.District").
                                                                                    Include("Property.Flat").
                                                                                        Include("Property.Floor").
                                                                                            Include("Property.PropDoc").
                                                                                                Include("Property.PropertySort").
                                                                                                    Include("Property.Project").
                                                                                                        Where(a =>a.User.Status == UserStatus.Active && a.AddStatus == AddStatus.Active && a.AddTypeID == Add.AddTypeID && a.Property.PropertySortId == Add.Property.PropertySortId && a.AddvertisimentID != Add.AddvertisimentID).
                                                                                                            OrderByDescending(a => a.CreatedAt).Take(8).ToList(),
                    },
                    Breadcumb = new BreadcumbViewModel
                    {
                        Title = "Elan haqqında",
                        Path = new List<BreadcumbItemViewModel>()
                    }
                };

                BreadcumbItemViewModel home = new BreadcumbItemViewModel
                {
                    Name = "Ana səhifə",
                    Controller = "Home",
                    Action = "index"
                };

                BreadcumbItemViewModel adds = new BreadcumbItemViewModel
                {
                    Name = "Bütün elanlar",
                    Controller = "Add",
                    Action = "index"
                };

                BreadcumbItemViewModel detail = new BreadcumbItemViewModel
                {
                    Name = "Elan haqqında"
                };

                data.Breadcumb.Path.Add(home);
                data.Breadcumb.Path.Add(adds);
                data.Breadcumb.Path.Add(detail);
                ViewBag.Partial = data.Breadcumb;
                ViewBag.Adds = data.AddsPanel;
                ViewBag.Owner = data.Owner;
                return View(data);
            }


        }

        public IActionResult Deactivate(int id)
        {
            var token = Request.Cookies["token"];

            if (token == null)
            {
                return RedirectToAction("index", "account");
            }

            Addvertisiment SelectedAdd = _context.Addvertisiments.Include("User").Where(a => a.AddvertisimentID == id && a.UserId == _auth.User.UserId).FirstOrDefault();

            if(SelectedAdd == null)
            {
                return BadRequest();
            }

            SelectedAdd.AddStatus = AddStatus.Deactive;

            _context.Entry(SelectedAdd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            //return RedirectToAction("index", "cabinet", new { id = _auth.User.UserId });

            List<Addvertisiment> DeactivatedAdds = _context.Addvertisiments.Where(a => a.AddStatus == AddStatus.Deactive).ToList();
            int DeactivatedAddsCount = DeactivatedAdds.Count();
           
            List<Addvertisiment> ActivedAdds = _context.Addvertisiments.Where(a => a.AddStatus == AddStatus.Active).ToList();
            int ActiveAddsCount = ActivedAdds.Count();
            
            List<Addvertisiment> WaitingdAdds = _context.Addvertisiments.Where(a => a.AddStatus == AddStatus.Waiting).ToList();
            int WaitingAddsCount = WaitingdAdds.Count();

            List<Addvertisiment> RentAdds = _context.Addvertisiments.Where(a => a.AddStatus == AddStatus.Active && a.AddTypeID<3).ToList();
            int RentAddsCount = RentAdds.Count();

            List<Addvertisiment> SaleAdds = _context.Addvertisiments.Where(a => a.AddStatus == AddStatus.Active && a.AddTypeID == 3).ToList();
            int SaleAddsCount = SaleAdds.Count();

            return Ok(
                new
                {
                    DeactivatedAddsCount,
                    ActiveAddsCount,
                    WaitingAddsCount,
                    RentAddsCount,
                    SaleAddsCount
                });
        }

        public IActionResult Remove(int id)
        {
            var token = Request.Cookies["token"];

            if (token == null)
            {
                return RedirectToAction("index", "account");
            }

            Addvertisiment SelectedAdd = _context.Addvertisiments.Include("User").Where(a => a.AddvertisimentID == id && a.UserId == _auth.User.UserId).FirstOrDefault();

            if (SelectedAdd == null)
            {
                return BadRequest();
            }

            SelectedAdd.AddStatus = AddStatus.Hidden;

            _context.Entry(SelectedAdd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            List<Addvertisiment> DeactivatedAdds = _context.Addvertisiments.Where(a => a.AddStatus == AddStatus.Deactive).ToList();
            List<Addvertisiment> AllAdds = _context.Addvertisiments.Where(a => a.AddStatus != AddStatus.Hidden).ToList();

            int DeactivatedAddsCount = DeactivatedAdds.Count();
            int AllAddsCount = AllAdds.Count();
           
            return Ok(
                new
                {
                    DeactivatedAddsCount,
                    AllAddsCount
                }
                );
        }

       
    }
}