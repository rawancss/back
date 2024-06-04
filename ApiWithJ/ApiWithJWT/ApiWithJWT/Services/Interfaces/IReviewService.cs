using ApiWithJWT.Dtos;
using ApiWithJWT.Dtos.Reviews;

namespace ApiWithJWT.Services.Interfaces;
public interface IReviewService
{
    Task<ReviewDto> CreateReviewService(ReviewDto newReview);
    void DeleteReviewService(Guid reviewId);
    Task<IEnumerable<ReviewDto>> GetAllReviewsService();
    Task<ReviewDto?> GetReviewByIdService(Guid reviewId);
	ReviewDto UpdateReviewService(Guid ReviewId, ReviewDto updatedReview);
}