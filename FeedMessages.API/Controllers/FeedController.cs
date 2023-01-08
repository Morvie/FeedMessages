using FeedMessages.API.Models;
using FeedMessages.Application.Commands.CreateFeed;
using FeedMessages.Application.Commands.DeleteFeed;
using FeedMessages.Application.Commands.UpdateFeed;
using FeedMessages.Application.Queries.GetAllFeeds;
using FeedMessages.Application.Queries.GetFeed;
using FeedMessages.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FeedMessages.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : Controller
    {
        private readonly IMediator _mediator;

        public FeedController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = new GetAllFeedsQuery();
            var result = await _mediator.Send(query);
            List<FeedViewModel> feeds = new();
            if (!result.Any()) return NoContent();
       
            foreach (var thread in result)
            {
                feeds.Add(new FeedViewModel(thread.Id, thread.TopicName, thread.Content, thread.Author, thread.CreatedAt, thread.LastEdited, thread.MovieId));
            }

            return Ok(feeds);
        }

        [HttpGet]
        [Route("/api/feed/movie/{id}")]
        public async Task<ActionResult>GetAll_ByMovieId(int id)
        {
            var query = new GetAllFeedsQuery();
            var result = await _mediator.Send(query);
            List<FeedViewModel> feeds = new();
            if (result == null) return BadRequest();

            foreach (var thread in result)
            {
                if(id == (thread.MovieId)) feeds.Add(new FeedViewModel(thread.Id, thread.TopicName, thread.Content, thread.Author, thread.CreatedAt, thread.LastEdited, thread.MovieId));         
            }
            if (feeds.Count().Equals(0)) return NoContent();
            
            return Ok(feeds);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var query = new GetFeedQuery(id);
            var feed = await _mediator.Send(query);
            if (feed == null) return NotFound();
            
            var thread = new FeedViewModel(feed.Id, feed.TopicName, feed.Content, feed.Author, feed.CreatedAt, feed.LastEdited, feed.MovieId);
            return Ok(thread);            
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateFeedViewModel createModel)
        {
            var query = new CreateFeedCommand(createModel.ForumId, createModel.Author, createModel.TopicName, createModel.Content, createModel.MovieId);
            var result = await _mediator.Send(query);

            if (result == null) return BadRequest();

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateFeedViewModel updatefeed)
        {
            var entity = new FeedDto() { TopicName = updatefeed.TopicName, Content = updatefeed.Content };
            var query = new UpdateFeedCommand(id, entity);
            var result = await _mediator.Send(query);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var query = new DeleteFeedCommand(id);
            var result = await _mediator.Send(query);
            if (result == null) return BadRequest();

            return Ok();
        }
    }
}
