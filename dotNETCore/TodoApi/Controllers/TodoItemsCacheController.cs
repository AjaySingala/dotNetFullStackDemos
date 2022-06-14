using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsCacheController : ControllerBase
    {
        private readonly TodoContext _context;
        private IMemoryCache _cache;
        private const string _todoListCacheKey = "todoList";

        private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
            new TodoItemDTO 
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };

        public TodoItemsCacheController(TodoContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache ?? throw new ArgumentNullException(nameof(cache)); 
        }

        // GET: api/TodoItemsCache
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
        {
            if (_context.TodoItems == null)
            {
                return NotFound();
            }

            if(_cache.TryGetValue(_todoListCacheKey, out IEnumerable<TodoItemDTO> todoItemsDTO))
            {
                Console.WriteLine("Todo List found in cache.");
            }
            else
            {
                todoItemsDTO = await _context.TodoItems
                    .Select(x => ItemToDTO(x))
                    .ToListAsync();
                
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                    .SetPriority(CacheItemPriority.Normal)
                    .SetSize(1024);

                _cache.Set(_todoListCacheKey, todoItemsDTO, cacheEntryOptions);
                Console.WriteLine("GetTodoItems(): Todo List added to cache.");
            }

            return Ok(todoItemsDTO);
        }

        // GET: api/TodoItemsCache/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
        {
            if (_context.TodoItems == null)
            {
                return NotFound();
            }

            if(_cache.TryGetValue(_todoListCacheKey, out IEnumerable<TodoItemDTO> todoItemsDTO))
            {
                Console.WriteLine("Todo List found in cache.");
            }
            else
            {
                todoItemsDTO = await _context.TodoItems
                    .Select(x => ItemToDTO(x))
                    .ToListAsync();
                
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                    .SetPriority(CacheItemPriority.Normal)
                    .SetSize(1024);

                _cache.Set(_todoListCacheKey, todoItemsDTO, cacheEntryOptions);
                Console.WriteLine("GetTodoItem(id): Todo List added to cache.");
            }

            var todoItem = todoItemsDTO
                .Where(t => t.Id == id)
                .FirstOrDefault<TodoItemDTO>();

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // PUT: api/TodoItemsCache/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItemDTO todoItemDTO)
        {
            Console.WriteLine("Entering PutTodoItem().");
            if (id != todoItemDTO.Id)
            {
                return BadRequest();
            }

            //_context.Entry(todoItem).State = EntityState.Modified;

            var todoItem = await _context.TodoItems.FindAsync(id);
            if(todoItem == null)
            {
                return NotFound();
            }

            todoItem.Name = todoItemDTO.Name;
            todoItem.IsComplete = todoItemDTO.IsComplete;

            try
            {
                await _context.SaveChangesAsync();
            }
            // catch (DbUpdateConcurrencyException)
            // {
            //     if (!TodoItemExists(id))
            //     {
            //         return NotFound();
            //     }
            //     else
            //     {
            //         throw;
            //     }
            // }
            catch(DbUpdateConcurrencyException) when (!TodoItemExists(id))
            {
                return NotFound();
            }

            // Reset Caching.
            _cache.Remove(_todoListCacheKey);
            Console.WriteLine("PutTodoItem(): Todo List removed from cache.");

            return NoContent();
        }

        // POST: api/TodoItemsCache
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoItemDTO>> PostTodoItem(TodoItemDTO todoItemDTO)
        {
            Console.WriteLine("Entering PostTodoItem().");
            if (_context.TodoItems == null)
            {
                return Problem("Entity set 'TodoContext.TodoItems'  is null.");
            }

            var todoItem = new TodoItem
            {
                IsComplete = todoItemDTO.IsComplete,
                Name = todoItemDTO.Name
            };

            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            // Reset Caching.
            _cache.Remove(_todoListCacheKey);
            Console.WriteLine("PostTodoItem(): Todo List removed from cache.");

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, ItemToDTO(todoItem));
        }

        // DELETE: api/TodoItemsCache/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            Console.WriteLine("Entering DeleteTodoItem().");
            if (_context.TodoItems == null)
            {
                return NotFound();
            }
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            // Reset Caching.
            _cache.Remove(_todoListCacheKey);
            Console.WriteLine("DeleteTodoItem(): Todo List removed from cache.");

            return NoContent();
        }

        private bool TodoItemExists(long id)
        {
            return (_context.TodoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
