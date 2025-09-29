using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class DepartmentController(IdepartmentServices _departmentService, IWebHostEnvironment _env, ILogger<DepartmentController> _logger) : Controller
    {
        #region Index
        // BaseUrl /Department /Index
        [HttpGet] // by default it's [Get]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }
        #endregion

        #region Create
        //Return View [Form]
        public IActionResult Create() // Get
        {
            return View(); // same name as action [Create] 
        }

        [HttpPost]
        public IActionResult Create(CreateDepartmentDto departmentDto)
        {
            //ModelState.AddModelError("Code", "Code must be greater than 100"); // Specific Field Error
            //ModelState.AddModelError(string.Empty, "Department cannot be created"); // General Error not related to specific field (Global Error Message) 

            if (ModelState.IsValid) // Server Side Validation
            {
                // Department ==> ManagerId [Employees 1 - 5 ]
                // Attribute ManagerId [Range(1 - 100)]
                // ManagerId = 6 (Exception it make error in database)
                try
                {
                    int result = _departmentService.AddDepartment(departmentDto);
                    if (result > 0)
                    {
                        //return View("Index");   [xxxxxxxxxx]
                        //return View("Index", _departmentService.GetAllDepartments());
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department cannot be created");
                    }
                }
                catch (Exception ex)
                {
                    // Development ==> action , log error in console , View [Same View]
                    if (_env.IsDevelopment())
                    {
                        _logger.LogError($"Department can not be created because : {ex.Message}");
                    }
                    else
                    {
                        _logger.LogError($"Department can not be created because : {ex}");
                        return View("ErrorView", ex); // Error View 
                    }
                    // Deployment ==> action , log error in file or database , View [Error View]
                }

            }
            return View(departmentDto);
        }
        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest(); // 400
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department == null) return NotFound(); // 404
            return View(department);

        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest(); // 400
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department == null) return NotFound(); // 404

            var departmentVM = new DepartmentEditViewModel
            {
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedOn = department.CreatedOn.HasValue ? department.CreatedOn.Value : default
            };
            return View(departmentVM);
            //return View(department); 
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, DepartmentEditViewModel departmentVM)
        {
            if (!ModelState.IsValid) return View(departmentVM);
            if (ModelState.IsValid)
            {
                try
                {
                    if (!id.HasValue) return BadRequest(); // 400
                    var updateDepartmentDto = new UpdatedDepartmentDto()
                    {
                        Id = id.Value,
                        Name = departmentVM.Name,
                        Code = departmentVM.Code,
                        Description = departmentVM.Description,
                        DateOfCreation = departmentVM.CreatedOn
                    };
                    int result = _departmentService.UpdateDepartment(updateDepartmentDto);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department cannot be updated");
                    }
                }
                catch (Exception ex)
                {
                    if (_env.IsDevelopment())
                    {
                        _logger.LogError($"Department can not be created because : {ex.Message}");
                    }
                    else
                    {
                        _logger.LogError($"Department can not be created because : {ex}");
                        return View("ErrorView", ex);
                    }
                }
            }
            return View(departmentVM);
        }
        #endregion

        #region Delete
        // Get ==> render View 
        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (!id.HasValue) return BadRequest(); // 400
        //    var department = _departmentService.GetDepartmentById(id.Value);
        //    if (department is null) return NotFound(); // 404
        //    return View(department); 
        //}


        [HttpPost]
        public IActionResult Delete([FromRoute] int id)
        {
            if (id <= 0) return BadRequest(); // 400
            try
            {
                bool isDeleted = _departmentService.DeleteDepartment(id);
                if (isDeleted)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Department cannot be deleted");
                }
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    _logger.LogError($"Department can not be Deleted because : {ex.Message}");
                }
                else
                {
                    _logger.LogError($"Department can not be Deleted because : {ex}");
                    return View("ErrorView", ex);
                }
            }
            return RedirectToAction(nameof(Delete), new { id });
        }

        #endregion

    }
}
