namespace Dispatcher.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Models.AdvertisementModels;

    public class AdvertisementSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Advertisements.Any())
            {
                return;
            }

            var ads = new List<Advertisement>();

            ads.Add(new Advertisement
            {
                AdvertisementTypeId = 1,
                Title = "Looking for Developers",
                Description = @"Does Upwork, Toptal, Stack Overflow sound familiar to you? If you’re looking to hire developers for your startup, you probably have already bumped into these websites and had no luck in finding the right person for the job. When you’re in the early stages of your business, making sure that you hire the right person for the role is vital. With 20% of startups failing in the first two years, and almost a quarter of failures being due to teamwork issues, getting this right is fundamental. We are familiar with the challenges, as we have been recruiting developers from all over the globe and placing them in different companies, for more than 10 years.

Developers are a key component for businesses. Now that the world has turned upside down and remote work is sweeping the corporate world, technology continues to innovate and change people’s lives. Through technology, you can create products and services that satisfy the customers’ needs. And companies now more than ever are aware of the need to increase their digital presence.

Whether you are building a mobile application, a website, or specific software, you’ll need a talented developer to help you succeed. But how to hire a developer for your startup when you A) have no technical experience or B) have a limited budget? ",
                Compensation = "6000 EUR",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
                PictureUrl = "https://getnave.com/blog/wp-content/uploads/2018/01/what-is-project-management-process.png",
            });

            ads.Add(new Advertisement
            {
                AdvertisementTypeId = 2,
                Title = "I will make your page",
                Description = @"We think you will agree with us if we say that becoming the top company in your industry might be difficult without the right people on your side.

Well, it turns out that having the right team members can easily turn your project into a success and this is why in this article we are going to explain to you why you should deliberate on getting yourself an experienced programmer.

If you are not a tech-savvy individual who wants to jump on board with app development for your business, DevsData has an article about app development for startups that can help you get started on your venture.

That does not mean that you cannot identify the traits of a good programmer yourself. We lined up a list of qualities you should search for when reviewing your candidates and looking for programmers.

However, before we move on to the above-mentioned list, let us give you a couple of tips on where actually you can look for talented engineers.",
                Compensation = "897 EUR",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
                PictureUrl = "https://www.arksolutions.de/wp-content/uploads/2018/10/Microsoft-Project-Roadmap.png",
            });

            ads.Add(new Advertisement
            {
                AdvertisementTypeId = 3,
                Title = "I need a job",
                Description = @"Top 7 sources of tech candidates
1. GitHub
GitHub is the world’s largest software development platform. It is a place where developers can host and review their code, manage projects, and build software alongside 31 million developers. Basically, it is a site where developers store their code and share it with others for collaboration, further development or simply usage.
2. Stack Overflow
Stack Overflow is the largest most trusted online community for developers to learn and share their knowledge. It has more than 50 million unique visitors come to Stack Overflow every month. Basically, Stack Overflow is a Q&A site. It is a place where developers post their programming-related questions and coding problems hoping that other developers will be able to help them. It has a very popular job board.
3. Dice
Dice is a well-known job board and candidate sourcing site. Dice’s database includes over 11 million unique and actionable tech profiles — including 2.2 million complete with résumés.
4. Toptal
Toptal is an exclusive network of the top freelance software developers, designers, finance experts, product managers, and project managers in the world. All candidates on Toptal have a proven track record and elite industry experience in design, business, or technology.
5. Upwork
Upwork is the largest global freelancing website. With millions of jobs posted on Upwork annually, freelancers are earning money by providing companies with over 5,000 skills across more than 70 categories of work.
6. We work remotely
We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board in the world with over 1.5 million individuals visiting the site annually. It is primarily comprised of developer jobs.
7. Gun.io
Gun.io is a platform which helps employers hire elite freelance software developers. All the developers on Gun.io are already tested and vetted. Gun.io has the most comprehensive vetting process in the entire freelance industry. While other sites just do automated code testing, Gun.io freelancers through four separate assessments. They test each freelancer’s technical acumen through an automated coding exam, a live coding exercise, and a technical interview with a member of our engineering team.",
                Compensation = "$5000",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
                PictureUrl = "https://fj-employer-blog.s3.amazonaws.com/employer-blog/wp-content/uploads/2015/11/5-Ways-to-Analyze-Employee-Performance-1024x508.jpg",
            });

            ads.Add(new Advertisement
            {
                AdvertisementTypeId = 4,
                Title = "Volunteers help for an app",
                Description = @"Need to find and hire developers?
Yes, we know…join the club, buddy! Finding and hiring developers is one of the top challenges for HR professionals and recruiters around the world.
However, finding great developers isn’t that hard — when you know where to look for them.
Download our free eBook: Definite Guide for Recruiting & Hiring Developers!
What are the best places to find developers?
The latest Stack Overflow’ survey The Global Developer Hiring Landscape 2018 has found that: only 16% of developers are actively looking for a job. This means that you won’t find them on LinkedIn, job boards and your career site.
You will find them, however, on specialized tech websites and forums. These websites are your best bet for finding and hiring top tech candidates, especially passive ones.",
                Compensation = "FREE",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
                PictureUrl = "https://www.volunteerworld.com/_Resources/Static/Packages/Vowo.Main/Images/Vowo_Logo.png",
            });

            ads.Add(new Advertisement
            {
                AdvertisementTypeId = 1,
                Title = "Looking for Developers",
                Description = @"Does Upwork, Toptal, Stack Overflow sound familiar to you? If you’re looking to hire developers for your startup, you probably have already bumped into these websites and had no luck in finding the right person for the job. When you’re in the early stages of your business, making sure that you hire the right person for the role is vital. With 20% of startups failing in the first two years, and almost a quarter of failures being due to teamwork issues, getting this right is fundamental. We are familiar with the challenges, as we have been recruiting developers from all over the globe and placing them in different companies, for more than 10 years.

Developers are a key component for businesses. Now that the world has turned upside down and remote work is sweeping the corporate world, technology continues to innovate and change people’s lives. Through technology, you can create products and services that satisfy the customers’ needs. And companies now more than ever are aware of the need to increase their digital presence.

Whether you are building a mobile application, a website, or specific software, you’ll need a talented developer to help you succeed. But how to hire a developer for your startup when you A) have no technical experience or B) have a limited budget? ",
                Compensation = "2000 EUR",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
                PictureUrl = "https://assets-global.website-files.com/5e3177cecf36f6591e4e38cb/5edb8e3526215b39bc1df752_Web-Dev-Studios-Logo.png",
            });

            ads.Add(new Advertisement
            {
                AdvertisementTypeId = 2,
                Title = "Do you need a shop?",
                Description = @"We think you will agree with us if we say that becoming the top company in your industry might be difficult without the right people on your side.

Well, it turns out that having the right team members can easily turn your project into a success and this is why in this article we are going to explain to you why you should deliberate on getting yourself an experienced programmer.

If you are not a tech-savvy individual who wants to jump on board with app development for your business, DevsData has an article about app development for startups that can help you get started on your venture.

That does not mean that you cannot identify the traits of a good programmer yourself. We lined up a list of qualities you should search for when reviewing your candidates and looking for programmers.

However, before we move on to the above-mentioned list, let us give you a couple of tips on where actually you can look for talented engineers.",
                Compensation = "1200 EUR",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
                PictureUrl = "https://i.ytimg.com/vi/OxFhwVXQS3E/maxresdefault.jpg",
            });

            ads.Add(new Advertisement
            {
                AdvertisementTypeId = 3,
                Title = "Hacker need a job!",
                Description = @"Top 7 sources of tech candidates
1. GitHub
GitHub is the world’s largest software development platform. It is a place where developers can host and review their code, manage projects, and build software alongside 31 million developers. Basically, it is a site where developers store their code and share it with others for collaboration, further development or simply usage.
2. Stack Overflow
Stack Overflow is the largest most trusted online community for developers to learn and share their knowledge. It has more than 50 million unique visitors come to Stack Overflow every month. Basically, Stack Overflow is a Q&A site. It is a place where developers post their programming-related questions and coding problems hoping that other developers will be able to help them. It has a very popular job board.
3. Dice
Dice is a well-known job board and candidate sourcing site. Dice’s database includes over 11 million unique and actionable tech profiles — including 2.2 million complete with résumés.
4. Toptal
Toptal is an exclusive network of the top freelance software developers, designers, finance experts, product managers, and project managers in the world. All candidates on Toptal have a proven track record and elite industry experience in design, business, or technology.
5. Upwork
Upwork is the largest global freelancing website. With millions of jobs posted on Upwork annually, freelancers are earning money by providing companies with over 5,000 skills across more than 70 categories of work.
6. We work remotely
We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board in the world with over 1.5 million individuals visiting the site annually. It is primarily comprised of developer jobs.
7. Gun.io
Gun.io is a platform which helps employers hire elite freelance software developers. All the developers on Gun.io are already tested and vetted. Gun.io has the most comprehensive vetting process in the entire freelance industry. While other sites just do automated code testing, Gun.io freelancers through four separate assessments. They test each freelancer’s technical acumen through an automated coding exam, a live coding exercise, and a technical interview with a member of our engineering team.",
                Compensation = "$23000",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
                PictureUrl = "https://images.idgesg.net/images/article/2019/06/dark_web_dark_net_warning_sign_alert_caution_danger_by_thomas-bethge_gettyimages-1151411167_black_and_yellow_warning_stripes_background_by_croc80_gettyimages-483040586_2400x1600-100800632-large.jpg",
            });

            ads.Add(new Advertisement
            {
                AdvertisementTypeId = 4,
                Title = "Need free hosting service",
                Description = @"Need to find and hire developers?
Yes, we know…join the club, buddy! Finding and hiring developers is one of the top challenges for HR professionals and recruiters around the world.
However, finding great developers isn’t that hard — when you know where to look for them.
Download our free eBook: Definite Guide for Recruiting & Hiring Developers!
What are the best places to find developers?
The latest Stack Overflow’ survey The Global Developer Hiring Landscape 2018 has found that: only 16% of developers are actively looking for a job. This means that you won’t find them on LinkedIn, job boards and your career site.
You will find them, however, on specialized tech websites and forums. These websites are your best bet for finding and hiring top tech candidates, especially passive ones.",
                Compensation = "FREE",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
                PictureUrl = "https://cdn.mos.cms.futurecdn.net/cRGZSUt6qTXqNGKsdtDCn7-1200-80.jpg",
            });

            ads.Add(new Advertisement
            {
                AdvertisementTypeId = 1,
                Title = "Looking for Designer",
                Description = @"Does Upwork, Toptal, Stack Overflow sound familiar to you? If you’re looking to hire developers for your startup, you probably have already bumped into these websites and had no luck in finding the right person for the job. When you’re in the early stages of your business, making sure that you hire the right person for the role is vital. With 20% of startups failing in the first two years, and almost a quarter of failures being due to teamwork issues, getting this right is fundamental. We are familiar with the challenges, as we have been recruiting developers from all over the globe and placing them in different companies, for more than 10 years.

Developers are a key component for businesses. Now that the world has turned upside down and remote work is sweeping the corporate world, technology continues to innovate and change people’s lives. Through technology, you can create products and services that satisfy the customers’ needs. And companies now more than ever are aware of the need to increase their digital presence.

Whether you are building a mobile application, a website, or specific software, you’ll need a talented developer to help you succeed. But how to hire a developer for your startup when you A) have no technical experience or B) have a limited budget? ",
                Compensation = "100 EUR",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
                PictureUrl = "https://public-images.interaction-design.org/literature/articles/heros/5806f96db228b.jpg",
            });

            ads.Add(new Advertisement
            {
                AdvertisementTypeId = 2,
                Title = "I will make your page",
                Description = @"We think you will agree with us if we say that becoming the top company in your industry might be difficult without the right people on your side.

Well, it turns out that having the right team members can easily turn your project into a success and this is why in this article we are going to explain to you why you should deliberate on getting yourself an experienced programmer.

If you are not a tech-savvy individual who wants to jump on board with app development for your business, DevsData has an article about app development for startups that can help you get started on your venture.

That does not mean that you cannot identify the traits of a good programmer yourself. We lined up a list of qualities you should search for when reviewing your candidates and looking for programmers.

However, before we move on to the above-mentioned list, let us give you a couple of tips on where actually you can look for talented engineers.",
                Compensation = "51000 EUR",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
                PictureUrl = "https://getbootstrap.com/docs/5.0/assets/img/bootstrap-themes.png",
            });

            ads.Add(new Advertisement
            {
                AdvertisementTypeId = 3,
                Title = "I need a job",
                Description = @"Top 7 sources of tech candidates
1. GitHub
GitHub is the world’s largest software development platform. It is a place where developers can host and review their code, manage projects, and build software alongside 31 million developers. Basically, it is a site where developers store their code and share it with others for collaboration, further development or simply usage.
2. Stack Overflow
Stack Overflow is the largest most trusted online community for developers to learn and share their knowledge. It has more than 50 million unique visitors come to Stack Overflow every month. Basically, Stack Overflow is a Q&A site. It is a place where developers post their programming-related questions and coding problems hoping that other developers will be able to help them. It has a very popular job board.
3. Dice
Dice is a well-known job board and candidate sourcing site. Dice’s database includes over 11 million unique and actionable tech profiles — including 2.2 million complete with résumés.
4. Toptal
Toptal is an exclusive network of the top freelance software developers, designers, finance experts, product managers, and project managers in the world. All candidates on Toptal have a proven track record and elite industry experience in design, business, or technology.
5. Upwork
Upwork is the largest global freelancing website. With millions of jobs posted on Upwork annually, freelancers are earning money by providing companies with over 5,000 skills across more than 70 categories of work.
6. We work remotely
We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board in the world with over 1.5 million individuals visiting the site annually. It is primarily comprised of developer jobs.
7. Gun.io
Gun.io is a platform which helps employers hire elite freelance software developers. All the developers on Gun.io are already tested and vetted. Gun.io has the most comprehensive vetting process in the entire freelance industry. While other sites just do automated code testing, Gun.io freelancers through four separate assessments. They test each freelancer’s technical acumen through an automated coding exam, a live coding exercise, and a technical interview with a member of our engineering team.",
                Compensation = "$400",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
                PictureUrl = "https://www.wpbeginner.com/wp-content/uploads/2021/05/webcomlogo.png",
            });

            ads.Add(new Advertisement
            {
                AdvertisementTypeId = 4,
                Title = "Volunteers for testing",
                Description = @"Need to find and hire developers?
Yes, we know…join the club, buddy! Finding and hiring developers is one of the top challenges for HR professionals and recruiters around the world.
However, finding great developers isn’t that hard — when you know where to look for them.
Download our free eBook: Definite Guide for Recruiting & Hiring Developers!
What are the best places to find developers?
The latest Stack Overflow’ survey The Global Developer Hiring Landscape 2018 has found that: only 16% of developers are actively looking for a job. This means that you won’t find them on LinkedIn, job boards and your career site.
You will find them, however, on specialized tech websites and forums. These websites are your best bet for finding and hiring top tech candidates, especially passive ones.",
                Compensation = "FREE",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
                PictureUrl = "https://www.hamburgsud-line.com/liner/media/hamburg_sud_liner_shipping/hs_stories/2021_4/aggrement_rates_red_notes.jpg",
            });

            ads.Add(new Advertisement
            {
                AdvertisementTypeId = 1,
                Title = "Looking for Designer",
                Description = @"Does Upwork, Toptal, Stack Overflow sound familiar to you? If you’re looking to hire developers for your startup, you probably have already bumped into these websites and had no luck in finding the right person for the job. When you’re in the early stages of your business, making sure that you hire the right person for the role is vital. With 20% of startups failing in the first two years, and almost a quarter of failures being due to teamwork issues, getting this right is fundamental. We are familiar with the challenges, as we have been recruiting developers from all over the globe and placing them in different companies, for more than 10 years.

Developers are a key component for businesses. Now that the world has turned upside down and remote work is sweeping the corporate world, technology continues to innovate and change people’s lives. Through technology, you can create products and services that satisfy the customers’ needs. And companies now more than ever are aware of the need to increase their digital presence.

Whether you are building a mobile application, a website, or specific software, you’ll need a talented developer to help you succeed. But how to hire a developer for your startup when you A) have no technical experience or B) have a limited budget? ",
                Compensation = "100 EUR",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
                PictureUrl = "https://public-images.interaction-design.org/literature/articles/heros/5806f96db228b.jpg",
            });

            ads.Add(new Advertisement
            {
                AdvertisementTypeId = 2,
                Title = "I will make your page",
                Description = @"We think you will agree with us if we say that becoming the top company in your industry might be difficult without the right people on your side.

Well, it turns out that having the right team members can easily turn your project into a success and this is why in this article we are going to explain to you why you should deliberate on getting yourself an experienced programmer.

If you are not a tech-savvy individual who wants to jump on board with app development for your business, DevsData has an article about app development for startups that can help you get started on your venture.

That does not mean that you cannot identify the traits of a good programmer yourself. We lined up a list of qualities you should search for when reviewing your candidates and looking for programmers.

However, before we move on to the above-mentioned list, let us give you a couple of tips on where actually you can look for talented engineers.",
                Compensation = "51000 EUR",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
                PictureUrl = "https://getbootstrap.com/docs/5.0/assets/img/bootstrap-themes.png",
            });

            ads.Add(new Advertisement
            {
                AdvertisementTypeId = 3,
                Title = "I need a job",
                Description = @"Top 7 sources of tech candidates
1. GitHub
GitHub is the world’s largest software development platform. It is a place where developers can host and review their code, manage projects, and build software alongside 31 million developers. Basically, it is a site where developers store their code and share it with others for collaboration, further development or simply usage.
2. Stack Overflow
Stack Overflow is the largest most trusted online community for developers to learn and share their knowledge. It has more than 50 million unique visitors come to Stack Overflow every month. Basically, Stack Overflow is a Q&A site. It is a place where developers post their programming-related questions and coding problems hoping that other developers will be able to help them. It has a very popular job board.
3. Dice
Dice is a well-known job board and candidate sourcing site. Dice’s database includes over 11 million unique and actionable tech profiles — including 2.2 million complete with résumés.
4. Toptal
Toptal is an exclusive network of the top freelance software developers, designers, finance experts, product managers, and project managers in the world. All candidates on Toptal have a proven track record and elite industry experience in design, business, or technology.
5. Upwork
Upwork is the largest global freelancing website. With millions of jobs posted on Upwork annually, freelancers are earning money by providing companies with over 5,000 skills across more than 70 categories of work.
6. We work remotely
We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board in the world with over 1.5 million individuals visiting the site annually. It is primarily comprised of developer jobs.
7. Gun.io
Gun.io is a platform which helps employers hire elite freelance software developers. All the developers on Gun.io are already tested and vetted. Gun.io has the most comprehensive vetting process in the entire freelance industry. While other sites just do automated code testing, Gun.io freelancers through four separate assessments. They test each freelancer’s technical acumen through an automated coding exam, a live coding exercise, and a technical interview with a member of our engineering team.",
                Compensation = "$400",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
                PictureUrl = "https://www.wpbeginner.com/wp-content/uploads/2021/05/webcomlogo.png",
            });

            ads.Add(new Advertisement
            {
                AdvertisementTypeId = 4,
                Title = "Volunteers for testing",
                Description = @"Need to find and hire developers?
Yes, we know…join the club, buddy! Finding and hiring developers is one of the top challenges for HR professionals and recruiters around the world.
However, finding great developers isn’t that hard — when you know where to look for them.
Download our free eBook: Definite Guide for Recruiting & Hiring Developers!
What are the best places to find developers?
The latest Stack Overflow’ survey The Global Developer Hiring Landscape 2018 has found that: only 16% of developers are actively looking for a job. This means that you won’t find them on LinkedIn, job boards and your career site.
You will find them, however, on specialized tech websites and forums. These websites are your best bet for finding and hiring top tech candidates, especially passive ones.",
                Compensation = "FREE",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
                PictureUrl = "https://www.hamburgsud-line.com/liner/media/hamburg_sud_liner_shipping/hs_stories/2021_4/aggrement_rates_red_notes.jpg",
            });

            await dbContext.Advertisements.AddRangeAsync(ads);
        }
    }
}
