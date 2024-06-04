using ApiWithJWT.Dtos;
using ApiWithJWT.Dtos.Reviews;
using ApiWithJWT.Models;
using ApiWithJWT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ApiWithJWT.Controllers;


[ApiController]
[Route("/api/reviews")]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;

	}

    [HttpGet]
    public async Task<IActionResult> GetAllReviews()
    {
        try
        {
            var reviews = await _reviewService.GetAllReviewsService();

            if (reviews.ToList().Count == 0)
            {
                return NotFound(new FailureResponse { Message = "No Reviews Found" });
            }

            return Ok(
                new SuccessResponse<IEnumerable<ReviewDto>>
                {
                    Message = "All Reviews Returned Successfully",
                    Data = reviews
                }
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to get all Reviews");
            return StatusCode(500, new FailureResponse { Message = ex.Message });
        }
    }



    [HttpGet("{ReviewId:guid}")]
    public async Task<IActionResult> GetReviewById(string ReviewId)
    {
        try
        {
            if (!Guid.TryParse(ReviewId, out Guid ReviewIdGuid))
            {
                return BadRequest("Invalid Review Id Format");
            }

            var fetchedReview = await _reviewService.GetReviewByIdService(ReviewIdGuid);

            if (fetchedReview == null)
            {
                return NotFound(
                    new FailureResponse { Message = "Review with that Id was not found" }
                );
            }
            else
            {
                return Ok(
                    new SuccessResponse<ReviewDto>
                    {
                        Message = "Review Returned Successfully",
                        Data = fetchedReview
                    }
                );
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to get that Review");
            return StatusCode(500, new FailureResponse { Message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateReview(ReviewDto newReview)
    {
        try
        {
            var createdReview = await _reviewService.CreateReviewService(newReview);
            return CreatedAtAction(
                nameof(GetReviewById),
                new { ReviewId = createdReview.ReviewId },
                createdReview
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to create the Review");
            return StatusCode(500, new FailureResponse { Message = ex.Message });
        }
    }

    [HttpPut("{ReviewId:guid=}")]
    public IActionResult UpdateReview(string ReviewId, ReviewDto updatedReview)
    {
        try
        {
            if (!Guid.TryParse(ReviewId, out Guid ReviewIdGuid))
            {
                return BadRequest("Invalid Review Id Format");
            }

            var existingReview = _reviewService.GetReviewByIdService(ReviewIdGuid);
            if (existingReview == null)
            {
                return NotFound();
            }

            _reviewService.UpdateReviewService(ReviewIdGuid, updatedReview);
            return Ok(updatedReview);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to update the Review");
            return StatusCode(500, new FailureResponse { Message = ex.Message });
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteReview(string id)
    {
        try
        {
            if (!Guid.TryParse(id, out Guid ReviewIdGuid))
            {
                return BadRequest("Invalid Review Id Format");
            }

            var ReviewToBeDeleted = await _reviewService.GetReviewByIdService(ReviewIdGuid);

            if (ReviewToBeDeleted == null)
            {
                return NotFound(new FailureResponse { Message = "Review not found" });
            }

            _reviewService.DeleteReviewService(ReviewIdGuid);
            return Ok(new SuccessResponse<ReviewDto> { Message = "Review Deleted Successfully", });
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to delete the Review");
            return StatusCode(500, new FailureResponse { Message = ex.Message });
        }
    }
}
