﻿using Microsoft.AspNetCore.Mvc;
using Readdit.Core.Contracts;
using Readdit.Core.DTOs;
using Readdit.ViewModels.Requests;

namespace Readdit.Controllers
{
    public class RequestController : BaseController
    {
        private readonly IRequestService requestService;

        public RequestController(IRequestService requestService)
        {
            this.requestService = requestService;
        }
        public async Task<IActionResult> All()
        {
            var model = await requestService.GetAllRequests(GetUserId());

            return View(model.Select(x => new ShowRequestViewModel(x)));
        }

        [HttpPost]
        public async Task<IActionResult> Upvote(int id)
        {
            var model = await requestService.GetRequest(id, GetUserId());
            if (model.IsUpvoted != null)
            {
                if (model.IsUpvoted == false)
                {
                    await requestService.UpvoteRequest(model.Id, GetUserId());
                }
                else
                {
                    await requestService.RemoveUpvoteRequest(model.Id, GetUserId());
                }
            }
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = new ShowRequestViewModel(await requestService.GetRequest(id, GetUserId()));
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new RequestEditViewModel(await requestService.GetAddNewRequest());
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RequestEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var newRequest = await requestService.GetAddNewRequest();
                model.Priorities = newRequest.Priorities;
                model.Categories = newRequest.Categories;
                return View(model);
            }
            if (model.CategoryIds.Count >= 0)
            {
                ModelState.AddModelError("", "There should be at least one category added.");
            }
            RequestAddDto dto = new RequestAddDto
            {
                CategoryIds = model.CategoryIds,
                Priority = model.Priority,
                Title = model.Title,
                Author = model.Author,
                Justification = model.Justification
            };
            await requestService.AddNewRequestAsync(dto, GetUserId());
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int id)
        {
            await requestService.ApproveRequest(id);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Decline(int id)
        {
            var model = new DeclineRequestViewModel(await requestService.GetRequest(id, GetUserId()));

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Decline(DeclineRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(new DeclineRequestViewModel(await requestService.GetRequest(model.Id, GetUserId())));
            }
            await requestService.DeclineRequest(model.Id, model.RejectionJustification);
            return RedirectToAction(nameof(All));
        }
    }
}
