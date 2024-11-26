using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server
{
    // 
    /* 
        This middleware is healing every 5min player/enemy HP in db.
        solution from:
            https://stackoverflow.com/questions/74501803/where-to-put-method-call-so-it-execute-at-every-5-minutes
    */
    public class AutoTimerHealingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly DataContext _context;
        public AutoTimerHealingMiddleware(RequestDelegate next, DataContext context)
        {
            _next = next;
            _context = context;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            var timer = new PeriodicTimer(TimeSpan.FromMinutes(5));
            int counter = 0;
            while (await timer.WaitForNextTickAsync())
            {
                counter++;
               // if (counter > 5) break;
                AddHealthEvery5Minutes(counter);
            }
            // Move forward into the pipeline
            await _next(httpContext);
        }
        public async void AddHealthEvery5Minutes(int counter)
        {
            List<Student> students = await _context.Students.Where(s => s.HealthPoints < s.MaxHealth).ToListAsync();

            List<Enemy> enemies = await _context.Enemies.Where(e => e.HealthPoints < e.MaxHealth).ToListAsync();
            
            foreach (var student in students)
            {
                if (student.HealthPoints + 5 > student.MaxHealth)
                {
                    student.HealthPoints +=  student.MaxHealth - student.HealthPoints;
                }
                else{
                    student.HealthPoints += 5;
                }
                await _context.SaveChangesAsync();
            }
            foreach (var enemy in enemies)
            {
                if (enemy.HealthPoints + 5 > enemy.MaxHealth)
                {
                    enemy.HealthPoints +=  enemy.MaxHealth - enemy.HealthPoints;
                }
                else{
                    enemy.HealthPoints += 5;
                }
                await _context.SaveChangesAsync();
            }

            Console.WriteLine("Current counter: {0} Last Fired At: {1}", counter, DateTime.Now);
        }
    }
}
