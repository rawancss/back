
using ApiWithJWT.Dtos;
using ApiWithJWT.Dtos.Reviews;
using ApiWithJWT.Services.Interfaces;

namespace ApiWithJWT.Services;

public class ReviewService : IReviewService
{
	public static List<ReviewDto> _reviews = new List<ReviewDto>()
	{

	};

	public async Task<IEnumerable<ReviewDto>> GetAllReviewsService()
	{
		return await Task.FromResult(_reviews.AsEnumerable());
	}

	public async Task<ReviewDto?> GetReviewByIdService(Guid reviewId)
	{
		return await Task.FromResult(_reviews.FirstOrDefault(r => r.ReviewId == reviewId));
	}

	public async Task<ReviewDto> CreateReviewService(ReviewDto newReview)
	{
		newReview.ReviewId = Guid.NewGuid();
		_reviews.Add(newReview);
		await Task.Delay(0);
		return newReview;
	}

	public ReviewDto UpdateReviewService(Guid ReviewId, ReviewDto updatedReview)
	{
		var existingReview = _reviews.FirstOrDefault(r => r.ReviewId == ReviewId);

		if (existingReview != null)
		{
			existingReview.Rating = updatedReview.Rating;
			existingReview.Comment = updatedReview.Comment ?? existingReview.Comment;

			if (existingReview.Rating == existingReview.Rating)
			{
				updatedReview.Rating = existingReview.Rating;
			}
		}
		return existingReview!;
	}

	public void DeleteReviewService(Guid reviewId)
	{
		var existingReview = _reviews.FirstOrDefault(r => r.ReviewId == reviewId);

		if (existingReview != null)
		{
			_reviews.Remove(existingReview);
		}
	}
}