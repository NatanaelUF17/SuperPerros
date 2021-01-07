using Microsoft.EntityFrameworkCore;
using SuperPerros.Context;
using SuperPerros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SuperPerros.Services
{
    public class PostServices
    {
        public readonly ApplicationDbContext context;

        public PostServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Save(Post post)
        {
            if (post.PostId > 0)
                return await Update(post);
            else
                return await Insert(post);
        }

        public async Task<bool> Insert(Post post)
        {
            bool isTrue = false;

            try
            {
                isTrue = await context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return isTrue;
        }

        public async Task<bool> Update(Post post)
        {
            bool isTrue = false;

            try
            {
                if (post != null)
                {
                    context.Entry(post).State = EntityState.Modified;
                    isTrue = await context.SaveChangesAsync() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return isTrue;
        }

        public async Task<bool> Delete(int id)
        {
            bool isTrue = false;

            try
            {
                var isFound = await context.Post.FindAsync(id);

                if (isFound != null)
                {
                    context.Post.Remove(isFound);
                    isTrue = (await context.SaveChangesAsync() > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return isTrue;
        }

        public async Task<Post> SearchPost(int id)
        {
            Post post = new Post();
            try
            {
                post = await context.Post
                    .Where(p => p.PostId == id)
                    .Include(pd => pd.PostDetail)
                    .FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return post;
        }

        public async Task<List<Post>> GetList(Expression<Func<Post, bool>> criteria)
        {
            List<Post> list = new List<Post>();

            try
            {
                list = await context.Post.Where(criteria).Include(x => x.PostDetail)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            List<Post> posts = new List<Post>();
            try
            {
                posts = await context.Post.Include(x => x.PostDetail)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return posts;
        }
    }

}
