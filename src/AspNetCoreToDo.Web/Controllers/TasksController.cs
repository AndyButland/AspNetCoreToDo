namespace AspNetCoreToDo.Web.Controllers
{
    using System.Threading.Tasks;
    using AspNetCoreToDo.Web.Commands.Tasks;
    using AspNetCoreToDo.Web.ViewModels.Tasks;
    using AutoMapper;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public class TasksController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        private const string NotificationMessageKey = "NotificationMessage";

        public TasksController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(TasksIndexViewModelQuery query)
        {
            var model = await _mediator.SendAsync(query);
            model.NotificationMessage = TempData[NotificationMessageKey] as string;
            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            var model = await _mediator.SendAsync(new TasksEditViewModelQuery());
            return View("Edit", model);
        }

        public async Task<IActionResult> Edit(TasksEditViewModelQuery query)
        {
            var model = await _mediator.SendAsync(query);
            if (model.Id == 0)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TasksEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new TaskAddOrEditCommand();
                _mapper.Map(model, command);
                var result = await _mediator.SendAsync(command);
                if (result.Success)
                {
                    TempData[NotificationMessageKey] = $"Task {(model.IsAdding ? "created" : "updated")}";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, result.ErrorMessage);
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(TasksDeleteViewModelQuery query)
        {
            var model = await _mediator.SendAsync(query);
            if (model.Id == 0)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(TasksDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new TaskDeleteCommand();
                _mapper.Map(model, command);
                var result = await _mediator.SendAsync(command);
                if (result.Success)
                {
                    TempData[NotificationMessageKey] = "Task deleted";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, result.ErrorMessage);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int id, bool completed, int? categoryId)
        {
            if (completed)
            {
                var command = new TaskCompleteCommand
                {
                    Id = id,
                };
                await _mediator.SendAsync(command);
                TempData[NotificationMessageKey] = $"Task marked as completed";
            }
            else
            {
                var command = new TaskResetCommand
                {
                    Id = id,
                };
                await _mediator.SendAsync(command);
                TempData[NotificationMessageKey] = $"Task reset";
            }
            
            return RedirectToAction("Index", categoryId.HasValue ? new { CategoryId = categoryId.Value } : null);
        }
    }
}