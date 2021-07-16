namespace Dispatcher.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Models.AdvertisementModels;

    public class JobSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Jobs.Any())
            {
                return;
            }

            var jobs = new List<Job>();

            jobs.Add(new Job
            {
                Title = "Software Engineer, Frontend at Welcome, Inc.",
                JobBody = @"Software Engineer, Frontend
•	U.S. REMOTE
•	ENGINEERING
•	FULL-TIME
Welcome is a virtual event platform for high-end, branded events. Using Welcome, a single person can create a jaw-dropping experience that feels like an Apple product launch. We’ve built the first five-star virtual event venue and have the product and services to match. Our flagship product allows our customers to create an event that feels like an interactive TV show. There is nothing else like it.
We’re well-funded by top VCs. Within three months of a soft launch we’ve already signed a Fortune 500 company and the world‘s largest investment fund. Over the next few years, we project that we will be the number one player in the space with massive market share, resulting in huge revenue and valuation.
This is an incredible opportunity for the right person to have a massive impact on Welcome’s business. We are growing insanely fast and looking for a strong frontend software engineer to join our world-class team, match the tsunami of demand we are already experiencing, and help us grow even faster.
You want your work to have significant and measurable positive impact. You love bringing people together. Your happiness comes from the joy of others, and you look forward to building stand-out moments of delight into the Welcome experience. You are a keen problem solver and team player. You take pride in the craftsmanship of your work, and appreciate when it is rewarded; our customers are fine with fewer features, but are not okay with broken features. The frontend software engineering role at Welcome encompasses architecture, design, implementation, and testing to ensure we build and release products in a way that upholds the luxury quality of our brand.
A day in the life of a Frontend Software Engineer at Welcome includes:
•	Being part of an inclusive, collaborative team that embraces healthy discussions and supports each other in their goals.
•	Architecting, designing, implementing, testing, and delivering robust and delightful products, continuing to keep the Welcome experience best-in-class.
•	Mastering our development process, culture, and code base, then improving it. Continually leaving each of these in a better state than when you found.
•	Working closely with our design team to understand the correct trade-offs and fully execute the UI/UX vision for our applications.
The next great Frontend Software Engineer at Welcome will have:
•	3+ years of professional software development experience
•	Deep understanding of web technologies, such as JavaScript, CSS, HTML5, and JSON. Our frontend is built in React.js and Redux
•	Excellent written and verbal communication skills
Bonus points if you have:
•	Experience building with WebRTC or other audio/video technologies
•	Experience with at least one backend web framework (Spring, Express, Rails, Django, et al.). Our backend is built in Ruby on Rails
•	Experience building highly concurrent and scalable web applications, understanding of browser/DOM performance
•	Track record of being a top performer in current and past roles
Our Investments in You:
•	Competitive salary and equity compensation
•	Medical, dental, and vision health insurance
•	Wellness/fitness & internet reimbursements
•	Top of the line 13-inch Macbook Pro
•	$1,000 home office and video conferencing budget (not including laptop) to create an accessible, productive, and comfortable work environment
•	Opportunity to work with tech’s best talent; An incredible team with a great blend of hustle, productivity and a ton of fun!
•	Opportunities to attend the most high-end virtual events in the world
",
                Location = "Remote",
                CompanyName = "Welcome, Inc.",
                Contact = "apply-welcome@welcome.com",
                LogoUrl = "https://remoteco.s3.amazonaws.com/wp-content/uploads/2021/07/15125054/welcome_inc-150x150.jpg",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
            });

            jobs.Add(new Job
            {
                Title = "Rails Full Stack Engineer at Assurant",
                JobBody = @"Title: Rails Full Stack Engineer

US Virtual
C: 7.63
This position is remote.
In this role, you will work closely with multiple product teams to create web and mobile client applications to serve customers with an engaging, dynamic user experience. We have seen people thrive in this role from a variety of backgrounds, but we work mostly in Ruby on Rails and React Native. This role is focused more on server development, so Rails experience is a plus, but not a requirement. Responsibilities include solving problems, experimenting, and building features that we measure for value to our users. Candidates must have strong communication skills, the ability to manage multiple tasks efficiently, sound judgment, and the ability to be productive in a fast-paced, team-oriented environment.

Responsibilities

Work in a collaborative environment by occasional pair and/or mob programming
Work closely with client developers to architect high-throughput systems
Communicate with Engineering Managers and Product Owners to plan and prioritize work and design technical solutions
Work in a cadence of two-week sprints with daily stand-ups and bi-weekly retrospectives
Conduct design and code reviews
Make disciplined use of source control and bug tracking systems
Grow subject matter expertise in programming, product, and platform
Unit-test code for robustness, including edge cases, usability and general reliability
Identify and resolve complex production issues
Collaborate with designers, content developers, and other software, site reliability, and QA engineers on cross-functional software products
Document best practices and help create a knowledge base
Requirements

Hands-on knowledge of version control systems such as Git
Ruby experience, or similar dynamic scripting language experience
Rails experience, or similar web framework experience
Experience with templating frameworks (e.g. Haml, ERb)
Experience consuming and maintaining RESTful APIs
Experience with MySQL and relational database design
A strong foundation in object-oriented or functional programming
Ability to demonstrate technical know-how through individual contributions, pair programming exercises, and architectural designs
A disciplined approach to development, testing, and quality assurance
Ability to reason with and adapt to evolving development tasks and priorities
Strong communication skills to create a productive communication environment with team members and stakeholders
Hopes

Experience and familiarity with Cloud Architecture (such as AWS or Azure)
Experience with testing frameworks such as RSpec and Cucumnber
Experience with GraphQL
Experience with Docker and/or Kubernetes
Experience with the Serverless framework for AWS Lambdas
Experience instrumenting applications with an analytics framework like Google Analytics or Mixpanel
Experience with React Native development
Willingness to participate in mentoring and skills transfer among team members
A continuous learning mindset that keeps you current on development best practices and trends
Desire for a deep technical understanding for the problems at hand
Ability to balance trade-offs between speed and quality based on business priorities
Technical leadership skills with the ability to resolve ambiguity in requirements",
                Location = "Berlin, Germany",
                CompanyName = "Assurant",
                Contact = "00421330332458, assurant@hr.de",
                LogoUrl = "https://remoteco.s3.amazonaws.com/wp-content/uploads/2020/03/23155207/assurant-150x150.jpg",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
            });

            jobs.Add(new Job
            {
                Title = "Senior Software Engineer – Full Stack at TeamSnap",
                JobBody = @"Senior Software Engineer – Full Stack (Multiple)

REMOTE /
ENGINEERING – ENGINEERING /
FULLTIME
About Us

TeamSnap is a sports and communication platform dedicated to empowering play in youth sports. We value trust, communication, and fun more than big company policies. We empower our people to bring big ideas and tiny egos which lands us on Outside Magazine’s list of “Best Places to Work” on the regular.

TeamSnap is seeking a Full-stack Senior Software Engineer interested in working across the stack to join our fully distributed engineering team to help us continue our impressive growth from 23 million customers to beyond! Similar roles include Senior Developer and Senior Full-stack Developer.

From a recent hackathon we released the first in industry health check screening for teams to help ensure members are healthy before competition of any kind. This had led our team to win the 2021 Big Innovation Award presented by the Business Intelligence Group!

To deepen our connections with each other, we also love to travel to fun locations across the country for all-company gatherings, team meetings, and the like.

What You’ll Be Doing

Building engaging new communication, commerce, and content features for our users.
Building new onboarding flows for users as we seek to continuously optimize.
Implementing custom sponsored experiences that are a win-win for our customers and brands.
Creating scalable and performant endpoints for our incredibly popular apps.
Working with the team to design new services and systems to support product features.
What You Need to Succeed

Experience leading projects for web apps and services at scale.
Exposure and interest in full-stack development. You have deep experience building experiences with Ruby or Elixir. You are also familiar with other languages and frameworks as well (we use Javascript, React, Redux).
Experience with direct usage of SQL and relational databases such as MySQL along with migrations, profiling, and optimization of such databases.
Excitement for building great solutions and user experience.
A sense of humor… or at least sympathy-laugh at our bad jokes.
Bonus Points

Experience working with functional programming concepts.
Familiar with Hooks and Component Lifecycle in React.
Ad Tech experience delivering and creating great user experiences.
Experience with Docker-based development environments and Kubernetes-based production environments.
Ability to talk to animals, Doctor Dolittle-style.
Got cold feet? If you’re thinking you don’t meet 100% of the above qualifications, you should still seriously consider applying. We’re all humans with special talents that go beyond what’s listed here.

Location

We are headquartered in Boulder, Colorado, but this job is remote (unless you happen to live near Boulder, in which case you’re welcome to come to the office). TeamSnap is a mostly-distributed company, so you must be very comfortable working with people who aren’t in the same physical location as you or each other. While we love all parts of the world, we can only hire permanent US residents at this time.

Benefits and Perks

TeamSnap provides you with a phenomenal culture, opportunities to develop professionally, and the ability to demonstrate what you can achieve. Benefits include:

We’re not just remote, we’re known for being remote-first. We’ve been working remotely since before COVID made it cool
Competitive salary and equity where everyone’s an owner
Unlimited PTO and paid parental leave for ALL parents (not just primary or secondary)
100% premium coverage of medical/dental/vision for you and your family
$1,500 learning and development stipend
401K and more!
Inclusion and Diversity

Bring your real self. Celebrate what makes you unique. Part of our commitment to inclusion and diversity includes deepening our relationships with our employee resource groups (women, people of color, and LGBTQ+). Our ERGs partner regularly with the executive team and people experience team to hold TeamSnap accountable in building an environment where everyone feels valued. We are an Equal Employment Opportunity Employer.",
                Location = "Sofia, Bulgaria",
                CompanyName = "TeamSnap",
                Contact = "teamSnap@haha.bg",
                LogoUrl = "https://remoteco.s3.amazonaws.com/wp-content/uploads/2015/07/teamsnap_twitter-150x150.png",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
            });

            jobs.Add(new Job
            {
                Title = "Software Engineer at Metadata.io",
                JobBody = @"About Us
We are a team of highly dedicated professionals who are making a breakthrough in B2B marketing by introducing an autonomous technology powered by AI to replace the daily mundane tasks of marketing operations teams, empowering them to execute 100x faster and more efficiently, freeing up time for creative and strategic tasks.

The company is  REMOTE with members spread out across 10 countries and 3 continents. We move fast but scientifically; we are agile but disciplined. We value and reward dedication, hard work, and a can-do attitude. We embrace equality, diversity, and authenticity. “Givers” will thrive in our team! 

Software Engineer 
We are seeking a unicorn Software Engineer who has a strong desire and drives to contribute to the next generation of our innovative product. As a Software Engineer at Metadata, you will have a chance to make deep technical contributions, manage your own priorities without supervision, participate in innovative tech design, understand how your work fits in with related projects or components, and help the team course-correct when necessary. 

It is a rare opportunity to boost your career growth, learn a lot, meet talented people, and work with cutting-edge technologies to transform B2B Marketing. 

The learning curve is steep and challenging, and the day-to-day life of a  Software Engineer requires sharp focus, exceptional attention to detail, an analytical approach, and continuous learning. 

If this sounds like the right opportunity for you, we want to hear from you as soon as possible! 

Required Skills
5+ years of experience as a Software Engineer 
Experience with Java, Hibernate, Spring, Tomcat, Redis, RabbitMQ
Database knowledge in technology such as with SQL/NoSQL Database 
Experience with search engines such as ElasticSearch, Solr
Should be comfortable with Linux (basic scripting language), Gitlab, Jira and a good grasp of the concept of DevOps and CI/CD
Proven experience with taking a feature request, providing tech design, implementing end-to-end, performing code review
Experience in writing unit tests using junits, wiremocks
Familiar cloud technologies such as Azure, AWS or DigitalOcean
Excellent understanding of design patterns, data structures, and algorithms
Proficient logical and analytical skills
Familiar with working in Agile environment and remote teams
Strong English speaking skills
Minimum 4 hours overlap with PST timezone
Bonus
Experience with big data technologies is a plus
Some experience with front-end technologies such as HTML, CSS, ReactJS, Jquery is nice-to-have
Some experience with Python and data analytics is nice-to-have
Advertising channels (Facebook, Linkedin, Quora, Adwords, Twitter) and/or Marketing technologies(Hubspot, Marketo, Salesforce etc) — a huge Plus
We Offer
Flexible remote work
Competitive salary
Flexible PTO and holidays
Opportunities to work with Machine Learning, Big Data Analytics, and new technologies
Friendly supportive team",
                Location = "International, Anywhere",
                CompanyName = "Metadata.io",
                Contact = "metadata@hr.io",
                LogoUrl = "https://remoteco.s3.amazonaws.com/wp-content/uploads/2020/09/28110927/metadata-150x150.png",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
            });

            jobs.Add(new Job
            {
                Title = "Senior UI – Front-End Developer at Interaction Design Foundation - IDF",
                JobBody = @"Senior UI/Front-End Developer

Do you want to use your coding skills to improve the lives of millions of people? Are you brave enough to let millions of UX designers use your code? Are you obsessive about your own professional development and continuous learning-through-doing? Then read on!

The Interaction Design Foundation is the biggest online design school globally. Founded in 2002, we have over 90,000 graduates and counting. We’re market leaders in online design education because the world’s leading experts create our content and because we’re specialized in design. What’s more, with over 1.5 million monthly visitors, we’re at the forefront of providing premier design education to such organizations as IBM and SAP, as well as thousands of other companies. Our ever-growing community now needs a first-class front-end developer to help craft the ultimate user experience.

This is where your passion for UX and hard-science coding skills merge: Every time your code is executed, you help improve the life of a human being. And not only that, those members will likely go on to design better products and services to the benefit of all humankind.

Our front-end code is a vital part of our winning formula: Our codebase is our baby and it can never become too perfect. You will, therefore, become an essential part of our long-term success, someone who is making a direct impact on not only the growth and reputation of our foundation but also the whole world of design education and beyond!

This is a paid full-time position which is location independent: You’re free to work from wherever you want in the world. You will have regular video-based contact with your colleagues and get to meet them physically on team trips.

What you will be doing

You will join our team as our Senior UI/Front-End Developer and your main responsibilities will be to:

Write reusable components using the Laravel Blade template engine, CSS and presentational JavaScript.
Help improve our Design System at https://design-system.interaction-design.org
Maintain our PostCSS code base to keep and improve reusability and DX and deliver less CSS to the end-user.
Improve CSS architecture and guidelines, make principal technical decisions in the UI area.
Help us use animations more widely, e.g. with Lottie animations.
Automate regression testing and front end code quality checks.
Improve the accessibility and performance of our pages.
Work with our design team to improve UX on different stages of the design process.
Work on PWA for our course platform as a part of the front-end team (offline support, better mobile experience, etc.)
Help yourself, and the whole team, get better and better. For example, by improving our handbook at https://handbook.interaction-design.org. Or use our library of evergreen literature on back-end and front-end subjects to broaden your horizon.
You and our future-proof stack

Forget IE and clunky workarounds for compatibility with other dinosaur browsers: We spend our time only on modern Web APIs since we only support evergreen browsers.

We’re constantly refactoring our front-end code with the goal of reaching front-end heaven. We seek a balance between sticking with what works and fearlessly exploring the new:

Laravel Blade template engine (yup, we build our HTML on the server-side).
PostCSS to maximize the power of modern CSS.
Webpack for perfect control over front-end assets.
Latest JS with support for ES2020 features. To accomplish this we use the latest Babel releases.
BEM/ITCSS in combination with Tailwind CSS based utility classes.
A custom-made design system (https://design-system.interaction-design.org) to achieve consistency and ease of use.
We love CI (Continuous Integration) and CD (Continuous Delivery) so we usually deploy a few releases per day: Zero downtime. Just a few buttons to push. No sweaty palms

We care deeply about Developer Experience (DX) of our codebase and tools. DX and DevOps is our middle name: git, GitHub, HTTP2, CDN, AWS, Enterprise SSDs on our high-spec servers and much more.

About you

You have at least 5 years of experience working as a Front-End Developer.
You prefer native web APIs and functionality over alluring new frameworks – and you know how and when to use them.
You regularly use WHATWG and W3C and you are intimately familiar with the latest web standards.
You can create your own intelligent, reusable CSS layout system.
You test across devices and browsers, and optimize for performance.
You write testable code.
You love to learn through doing. You’re always ready to put in some hard work to expand your skills.
You speak and write acceptable English – not perfect English, just acceptable – since you will be working with people from Canada, England, Denmark, the US, Belarus and Brazil among others.
You are a team player and you don’t bring your ego to work.
You are self-motivated and self-disciplined and thus work well in a flat hierarchy with lots of freedom.
You love to have creative freedom, make independent judgments and live up to the responsibility that comes with that freedom.
You love to create tangible results—every hour and every day.
Bonus points

You get bonus points…

…if you have contributed to open source
…if you have a Master’s Degree in Computer Science
…if you have PHP coding experience
…if you have read articles from the following authors:
Heydon Pickering https://heydonworks.com/latest
Rob Dodson
Sara Soueidan https://www.sarasoueidan.com/blog/",
                Location = "Munich, Germany",
                CompanyName = "Interaction Design Foundation - IDF",
                Contact = "0042136999874522, idf@idf.de",
                LogoUrl = "https://remoteco.s3.amazonaws.com/wp-content/uploads/2018/11/interaction_design_foundation-150x150.jpg",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
            });

            jobs.Add(new Job
            {
                Title = "Software Engineer – Fullstack at Stitch Fix",
                JobBody = @"Title: Software Engineer (Fullstack)

Location: Remote, USA
At Stitch Fix, our goal is to help our customers look great and feel great about themselves by revolutionizing how people shop. In a time-starved world where shopping often feels overwhelming, our business connects customers to clothes they love. Whether it’s helping someone dress for success at a new job or taking the stress out of packing for a family vacation, we fix clients’ closets and they love us for it!

We’ve built unique, innovative software for merchandising, warehouse and inventory management, remote styling, and logistics. We leverage vast amounts of client data to make decisions throughout the company. All of this results in a simple, powerful offering to our clients and a very successful business. We believe we are only scratching the surface of our opportunity, and we’re looking for incredible people to contribute!

Software Engineer (SE2/3 Fullstack)

Stitch Fix is transforming the way people find what they love. Our technology teams have created unique, innovative software for our customers as well as employees in merchandising, styling, warehouse systems, and inventory management. We leverage data and user research to personalize our service and make smart bets. The result is a delightful offering for our customers and a successful business serving millions of women, men, and kids. We’re looking for outstanding people to contribute to our evolution.

ABOUT THE ROLE

You will work within a distributed team of 4-8 software engineers and cross-functional partners including product, design, data science and operations. You’re expected to have strong written communication skills and be able to develop strong working relationships with coworkers and business partners.

You will be working on our customer facing systems, creating the future of how Stitch Fix’s clients browse and buy, or in our Merchandising, Styling or Warehouse Systems, creating the future of how Stitch Fix’s clients are styled, shown outfits and receive their purchases. We expect you to ask a lot of questions!

This is a remote position available within the United States. We welcome people from all backgrounds: self-taught, bootcamp grads, history majors, consultants, parents, computer scientists, athletes, musicians, oxford comma proponents, and more. We build modern software with modern techniques like TDD, continuous delivery, DevOps, and service-oriented architecture. We focus on high-value products that solve clearly identified problems but are designed in a sustainable way and deliver long term value.

RESPONSIBILITIES INCLUDE:

Operate as an engaged member of the engineering team by contributing to meetings, providing input on technical design documents & project plans, pairing with other engineers to work toward a solution.
Collaborating with your team and stakeholders during execution of projects to deliver results against measurable goals.
Participating in on-call rotations once confidently onboarded to the team.
Write and review code in Ruby or Golang, JavaScript, and CSS used in applications built in React or Rails.
REQUIREMENTS

You are bright, kind, and motivated by challenge
Are enthusiastic about technology
Are respectful, empathetic, and curious
Thrive in collaborative teams with a shared goal
Have strong written and verbal communication skills
Take initiative and are excited by new problems
Have 2+ years of professional programming experience.
Will need guidance from time to time, but you are good at getting yourself un-stuck
Might have experience with building APIs and micro-services
Might have experience with Postgres, Redis and/or RabbitMQ
Might have experience working remotely
OUR TECH STACK INCLUDES…

React, JavaScript, TypeScript, CSS, HTML
GraphQL and Postgres
Ruby, Rails, Golang and some Node.js
RabbitMQ and Kafka
YOU’LL LOVE WORKING AT STITCH FIX BECAUSE WE…

Are a successful, vibrant, fast-growing company
Are a technologically and data-driven business.
Are at the forefront of tech and fashion, redefining shopping for the next generation.
Are passionate about our clients and live/breathe the client experience.
Get to be creative every day.
Have a smart, experienced, and diverse leadership team that wants to do it right & is open to new ideas.
Believe in autonomy & taking initiative.
Fully support remote work and you get to visit our SF office every few months to connect with your peers and partners.
Offer transparent, equitable, and competitive compensation based on your level to help eliminate bias in salaries, as well as equity and comprehensive health benefits.
Are serious about our commitment to life-work balance, and have generous parental leave policies.",
                Location = "Remote",
                CompanyName = "Stitch Fix",
                Contact = "fake@email.com",
                LogoUrl = "https://remoteco.s3.amazonaws.com/wp-content/uploads/2016/12/Stitch_Fix-150x150.jpg",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
            });

            jobs.Add(new Job
            {
                Title = "Front-End Software Engineer III at Particle",
                JobBody = @"Position Overview

Particle is hiring an engineer to work on the web front-end applications that our customers use to both manage their IoT device experience on the Particle platform, from fleet health through to use case specific applications. To most of our customers, this IS the Particle experience and you would be joining us right as we begin the rebuilding of our existing web properties and internal systems. In this role, you will build, deploy, test and monitor a suite of applications that enable product creators to rapidly deploy and scale an IoT solution.

You will:

Develop web front-end applications. You will write code and implement UIs for the web front-end applications used by our most important enterprise customers to manage large fleets of Internet of Things (IoT) devices in real world deployments. With any support needed, you will also dive into our backend applications like the Particle REST API, our GraphQL API, making unified front and backend changes that are deployed in tandem. We are a product driven agile shop and the Particle Product Team will define much of the work you do, producing designs and user stories that describe the user experience on our platform. You will test your code using unit and integration tests that run under continuous integration because we love well tested systems for the stable experience it brings to our customers. You will validate your changes using real Particle cellular devices connected to the Particle cloud platform.
Ensure the performance, reliability and security of front-end applications. You will instrument the applications to report user activity metrics and participate in triaging issues reported by customers as well as those logged automatically in our error tracking system (we use Sentry!), and work to resolve issues by order of priority. You will update dependencies to keep applications up to date and you will collaborate with the security team to respond to security vulnerability reports. Security work is taken seriously and we will also fix know defects over product updates.
Design the future of the Particle Cloud. You will collaborate with the Product team, lead engineers and UI designers to provide users with a good experience at all stages of their journey managing their IoT product. You will plan your work for 2 week agile sprints and ship with our team a major product update every 6 weeks
Work daily with a global team. You’ll be working daily with a global team of engineers, designers and product managers and your excellent written and oral technical communication are the secret sauce that enables you to amplify your contributions across the team. You will participate in code reviews to learn about other parts of the Particle cloud, and share your knowledge with other engineers.
You should have:

3+ years experience developing web-end applications in React and / or React Native
Expertise in Javascript with a firm understanding of its most common runtimes (Browsers, Node.js)
Experience with modern front-end tooling like bundlers (webpack), package managers (npm, bower) and testing frameworks (Jest, Mocha)
Familiarity with Typescript and the tools and techniques required to build productions systems with it
A deep understanding of HTML5 and CSS
An understanding of web technologies (HTTP, REST APIs, web servers)
Experience with test-driven development, continuous integration and continuous deployment
A strong understanding of git and the GitHub platform
Phenomenal communication skills, both written and verbal
Experience working remotely for a U.S. based company
Nice to have:

Experience designing UIs and working w/ common design tools
General understanding of good UX practices
Experience with Node.js for back-end development
We provide:

Competitive medical, dental, vision, disability, and life insurance
Stock options
Flexible and open vacation policy
Work from home stipend
Generous parental leave policy
A robust wellness program with individual, personalized coaching",
                Location = "California, USA",
                CompanyName = "Particle",
                Contact = "particle@fake.usa",
                LogoUrl = "https://remoteco.s3.amazonaws.com/wp-content/uploads/2016/06/particle_square-150x150.png",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
            });

            jobs.Add(new Job
            {
                Title = "Senior Full Stack Engineer – Client at TaskRabbit",
                JobBody = @"Title: Senior Full Stack Engineer – Client

Location: United States

TaskRabbit is a remote-first company with employees distributed across the USA!
DataBird journal’s Best Places Best Companies for Diversity, #1 2019 and 2020
DataBird journal’s Best Places Best Companies for Women, #4 2019 and #1 2020
About the Job

This role is on the Client team. Our team focuses on building and improving the experience of our Client customers, who come to TaskRabbit to get the support and help they need to check items off their to-do list, allowing them to book tasks and communicate with Taskers. Our objective is to make it easy for Clients to find the right Taskers for their projects via our core mobile app and our web platform.

As a Senior Software Engineer, you’ll be one of the leaders of our team helping to mentor more junior engineers, propose scalable solutions, and de-tangle the complex into the simple. You should be comfortable building complex solutions to full stack challenges, and you’ll have the opportunity to contribute to the development of APIs and full stack features across our Client web and Client mobile platforms.

Join us in creating a better everyday life for everyday people.

You will be:

Collaborating with design and product management to conceptualize new product features from the ground up
Work alongside more junior software engineers to help them think through designs, code implementation, and how to break down their goals into actionable steps
Innovate & contribute to our technical roadmap of ongoing improvements, enhancements and updates
Participate in code reviews, listening to feedback and commenting on other approaches
Invest in the documentation of best practices and coding patterns
Help solve complex debugging, testability, and deployability problems
Collaborate across teams to promote consistency
Improve stability and consistency of existing and new backend & frontend code
You should have:

5+ years of experience, comfortable working independently
Proficient with Ruby on Rails, Javascript or Front end componentized frameworks such as React.js (React Native is a plus)
Experience building API-driven applications or endpoints
Proficient understanding of how to organize code across the stack: what belongs in the frontend, what in the back
Experience with feature flagged development
Comfortable with automated testing and JS build and packaging systems like Webpack and Jest
A strong advocate of clean code
You might be a fit if you have:

Strong written and verbal communication skills
Enjoy helping organize and scope high priority projects and plans to keep us moving forward
Have a great attention to detail and quality
Any GraphQL or Federated API layer experience
Personally have implemented more automated QA and/or CI/CD tooling
About TaskRabbit

TaskRabbit is a marketplace platform that conveniently connects people with Taskers to handle everyday home to-do’s, such as furniture assembly, handyman work, moving help, and much more. Acquired by IKEA Group – the world’s largest furniture retailer – in 2017

At TaskRabbit, we want to make your neighborhood a little more familiar. Whether it’s a handyman (or woman!), a housecleaner, moving help or delivery person, we’re imagining a world where everyone will have a go-to team to make everyday life easier. As a company we celebrate innovation, inclusion and hard work.

As a pioneer of the sharing economy, TaskRabbit was founded on the premise of neighbors helping neighbors. Since then, our network has grown to eight countries and 75+ cities, yet our core mission of creating a better everyday life for everyday people has remained the same.

Together with IKEA, we’re creating more opportunities for people to earn a consistent, meaningful income on their own terms by building lasting relationships with clients in communities around the world.

We are a group of mission-minded people. Our culture is collaborative, pragmatic, and fast-paced. We’re looking for talented, entrepreneurially-minded and data-driven people who also have a passion for helping people do what they love – and have a ton of fun while they’re at it.

You’ll love working here because:

TaskRabbit is a remote first company. We recognize that talented people live all over the world.
Collaboration hub offices in San Francisco, Austin and London
The People. You will be surrounded by some of the most talented, supportive, smart, and kind leaders and teams — people you can be proud to work with!
Senior Leadership Team 75% women
Director Level 86% Diverse
The Values:
Care Deeply. We take time to be present and partner with our team and communities.
Level Up. We navigate through ambiguity and go the extra mile.
Be A Better Neighbor. We build a diverse and sustainable community and encourage all voices.
Lead The Future Together. We value entrepreneurship and are inspire by action.
The diverse culture. We believe that we make better decisions when our workforce reflects the diversity of the communities in which we operate. Women make up more than half of our team and leadership, and we strive to recruit and retain employees from all over the world.
The perks:
Comprehensive medical, dental, vision 100% covered for employees
401k plan with company matching
Generous and flexible vacation and holiday time off
Commuter benefits
Learning and development opportunities
Career development trainings
Monthly TaskRabbit product stipends
IKEA discounts
Weekly meditations
Dog-friendly office
Equal Opportunity Employer

TaskRabbit is an equal opportunity employer and values diversity at our company. We do not discriminate on the basis of race, religion, color, national origin, ancestry, citizenship, gender, gender identity, sexual orientation, age, marital status, military/veteran status, or disability status. TaskRabbit is committed to working with and providing reasonable accommodation to applicants with physical and mental disabilities.

TaskRabbit will consider for employment all qualified applicants with criminal histories in a manner consistent with applicable law.",
                Location = "United States",
                CompanyName = "TaskRabbit",
                Contact = "09023009349034, rabbitv@hr.com",
                LogoUrl = "https://remoteco.s3.amazonaws.com/wp-content/uploads/2018/09/task_rabbit-150x150.jpg",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
            });

            jobs.Add(new Job
            {
                Title = "Software Engineer – Backend/Python (Americas & European time zones) at Close",
                JobBody = @"About Us
At Close, we’re building the sales communication platform of the future. With our roots as the very first sales CRM to include built-in calling, we’re leading the industry toward eliminating manual processes and helping companies to close more deals(faster). Since our founding in 2013, we’ve grown to become a profitable, 100% globally distributed team of ~45 high-performing, happy people that are dedicated to building a product our customers love.
Our backend tech stack currently consists of Python Flask web apps with our TaskTiger scheduler handling many of the backend asynchronous task processing chores. Our data stores include MongoDB, Postgres, Elasticsearch, and Redis. The underlying infrastructure runs on AWS using a combination of managed services like RDS and ElasticCache and non-managed services running on EC2 instances. All of our compute runs through CI/CD pipelines that build Docker images, run automated tests and deploy to our Kubernetes clusters.Our backend primarily serves a well-documented public API that our front-end JavaScript app consumes.
We 💛 open source – using dozens of open source projects with contributions to many of them, and released some of our own like ciso8601, LimitLion, SocketShark, TaskTiger, and more at https://github.com/closeio
About You
We’re looking for an experienced full-time Software Engineer to join our engineering team. Someone who has a solid understanding of web technologies and wants to help design, implement, launch, and scale major systems and user-facing features.
You should have senior level experience (~5 years) building modern back-end systems, with at least 3 years of that experience using Python.
You have hands on production experience woking with MongoDB, PostgreSQL, Elasticsearch, or similar data stores. You have significant experience designing, scaling, debugging, and optimizing systems to make them fast and reliable. You have experience participating in code reviews and providing overall code quality suggestions to help maintain the structure and quality of the codebase. You care about the craftsmanship of the code and systems you produce.
You’re comfortable working in a fast-paced environment with a small and talented team where you’re supported in your efforts to grow professionally. You are able to manage your time well, communicate effectively and collaborate in a fully distributed team.
You are located in an American or European time zone.
Bonus points if you have…
Contributed open source code related to our tech stack
Led small project teams building and launching features
Built B2B SaaS products
Experience with sales or sales tools
Come help us with projects like…
Conceiving, designing, building, and launching new user-facing features
Improving the performance and scalability of our GraphQL and REST API.
Improving how we sync millions of sales emails and calendar events each month
Working with Twilio’s API, WebSockets, and WebRTC to improve our calling features
Building user-facing analytics features that provide actionable insights based on sales activity data
Improving our Elasticsearch-backed powerful search features
Improving our internal messaging infrastructure using streaming technologies like Kafka and Redis
Building new and enhancing existing integrations with other SaaS platforms like Google’s G Suite, Zapier, and Web Conferencing providers
Why work with us?
Culture video 💚
Our story and team 🚀
100% remote-first company (we believe in trust and autonomy)
2 x annual team retreats ✈️ (Lisbon Retreat Video) – when travel is appropriate
4 x quarterly virtual summits
7 weeks PTO (includes company-wide winter holiday break)
2 additional PTO days every year with the company
1 month paid sabbatical every 5 years
$200/month co-working stipend
Revenue Share (after 1 year)
Choose between working 5 days/wk (standard full-time) or 4 days/wk @ 80% pay
Paid parental leave (10 wks primary caregiver / 4 wks secondary caregiver)
99% premiums paid for excellent medical and dental coverage, including an HSA option (US residents)
401k matching at 6% (US residents)
Dependent care FSA (US residents)
We are a small team doing great things – every role is critical to the success of this company. People that are most successful at Close have a resourceful, “doer” approach and mentality. We focus on productivity, impact and quality of work. We’re looking for team members that genuinely understand the nature of being part of a small team that operates in a bootstrapped / start-up-like environment.
At Close, everyone has a voice. We encourage transparency and practicing a mature approach to the work-place. In general, we don’t have strict policies, we have guidelines. Life-work harmony is an important part of our organization – we believe you bring your best to work when you practice self-care (whatever that looks like for you).
We come from 12 countries and 16 states; a collection of talented humans rich in diverse backgrounds, lifestyles, and cultures. Twice a year we meet up somewhere around the world to spend time with one another (however we’re opting for quarterly virtual summits during 2020/2021). We see these retreats as an opportunity to strengthen the social fiber of our community. This team is growing in more ways than one – we’ve recently launched 14 babies (and counting!).
Unanimously, our favorite and most impactful value is “Build a house you want to live in.” We strive to make decisions that are authentic for our organization. At Close, we have a high care factor for one another, in making an awesome product and championing the success of our customers.
Interested in Close but don’t think this role is the best fit for you? View our other positions.",
                Location = "Americas & European time zones",
                CompanyName = "Close",
                Contact = "fake@mail.net",
                LogoUrl = "https://remoteco.s3.amazonaws.com/wp-content/uploads/2021/01/19130351/CloseLogo-150x150.png",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
            });

            jobs.Add(new Job
            {
                Title = "Engineering Manager at Fold",
                JobBody = @"Job Description – Engineering Manager

We’re here to introduce the world to Bitcoin. Fold makes it easy to earn bitcoin, instead of airline miles and hotel points, on everyday purchases via our mobile app and the Fold Visa Debit Card. We’re growing like crazy with a loyal (and loud!) community which has generated a lot of buzz (Fortune, Bloomberg).

The Software Engineering Manager at Fold reports to the Head of Engineering and will play a key role in leading the team’s technical direction and integration with enterprise solutions. The Software Engineering Manager will form effective partnerships across Fold’s individual business units.

The Manager collaborates with various levels of stakeholders (Sr. Leadership, each department’s management, project teams, and enterprise architects) on architecture, requirements, and implementation of technical solutions; Possess a combination of systems and technology experience along with strong thought leadership make the right and balanced technical decisions that deliver key enabling features to support the business.

The Software Engineering Manager will evangelize use of modern software development practices, with emphasis on automation and reliability engineering. Build and lead high performing software engineering teams to deliver and support multiple applications and services at speed and scale; Drive innovation in both technology and process; Inspires the teams to achieve outstanding results in a fast-paced environment.

How You’ll Drive the Development of the Fold Card:

Architect and build scalable software solutions.
Participate and coach in a stand up and be able to interact with business partners and cross functional IT leadership
Build and manage software delivery, systems integration, and developer support tools.
Work with other technical teams to ensure technical strategies, architecture guidelines and standard are realized by efficient collaboration with architecture, development, DevOps and other teams.
Plan and lead technology evaluation for various critical areas working closely with cross functional teams.
Manage geographically distributed engineering scrum-teams using agile development and DevOps best practices.
Technical definition and implementation for analytics, error logging/tracking, and other key functional customer interactions
Bring innovative ideas to the table every day, in order to find better ways of accomplishing our customer objectives. Set clear, measurable quality goals for an organization in a data-driven way.
Production issue triage, management, and prevention as needed
Foster culture of continuous engineering improvement through mentoring, feedback, and metrics.
Hire, coach, and mentor individuals; build a strong cross-functional organization.
Why We’ll Love You:

Bachelor’s Degree from a 4-year college or university
8+ years of direct experience
Must also have broad and deep technical understanding of the technologies in this field, including but not limited to:
Front End technologies like ReactJS / Angular
Experience with
Experience working with
Strong data management principles, around data architecture, modeling/design, data quality, security, data organization and operations.
Preferred – Experience implementing
Ability to effectively share technical information, communicate technical issues and solutions to all levels of business
Able to juggle multiple projects – can identify primary and secondary objectives, prioritize time and communicate timeline to team members
Ability and desire to take product/project ownership
Ability to work a flexible schedule based on department and Company needs.
Why You’ll Love Us:

We’re a highly collaborative, fully remote team
Generous benefits, including health, vision and dental insurance
Unlimited time off policy – we trust you to manage your own time
Paid parental leave
Company retreats and onsite meetings (at least, after COVID)
Location: US Locations Only

Apply to: people@foldapp.com",
                Location = "Lion, France",
                CompanyName = "Fold",
                Contact = "people@foldapp.com",
                LogoUrl = "https://remoteco.s3.amazonaws.com/wp-content/uploads/2021/06/28171231/fold-app-150x150.png",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
            });

            jobs.Add(new Job
            {
                Title = "UI – UX Front-End Developer",
                JobBody = @"UI/UX Front-End Developer (m/f/d)

REMOTE
Tech
Contract
Description

We are a digital media and games company. On a daily basis, we reach millions of users with our content, projects and games, such as the Nametests Instant Game on Facebook. We are a creative team pursuing our mission to “make people smile”; we are committed to entertaining people and aim to inspire their world.

We use the latest technology in order to be highly adaptive. Combined with our agile spirit and great teamwork, this allows us to achieve:

More than 500 million people who played our games
More than 120 million fans on Facebook
Content and mini-games translated into more than 40 different languages
The Social Sweethearts are looking for passionate and dynamic colleagues who would like to join us in continuing to create a more colorful world.

Join our team as a UI/UX Front-End Developer (m/f/d) and let’s do the following together:

Implement interactive Game UIs for our new Facebook Instant Games, using modern JavaScript frameworks (like React and Vue).
Help maintain our core product: The Nametests Instant Game on Facebook, with millions of active players globally.
You will be part of a team of technical experts! The team shares the responsibility to work on the public products and to ensure a no-downtime, performant and stable quality gaming experience for millions of users globally.
In your team, the highest goal is quality software, focussing on maintainability, efficiency, performance and solid software architecture.
Requirements

Expert-level experience with interactive UI/UX Design and Implementation
Strong technical experience in Front-End technologies, especially HTML, CSS (SASS, Transitions, Animations) and Javascript
Experience with Front-End standards like BEM, Atomic Design and WebComponents
Ideally, experience in using state of the art design tools like Adobe Illustrator, Sketch or comparable
Ideally, experience in using Game Engines compatible with the Facebook platform such as babylonJS, createJS, pixiJS, Egret Engine etc.
Experience using source code repositories (Github, Gitlab) and deployment pipelines (CI/CD)
Benefits

Friendly, collegiate atmosphere with colleagues who complement one another with their skills.
Highly valuing technical excellence and high-quality software.
Down-to-earth founders and management, who understand their role as servant leaders.
With an English office language, we are an international and diverse team with people from all over the world.
Active input on products that are used and downloaded globally by millions of users.
Emphasis on a healthy work-life balance, with flexible working hours and extensive remote work / home-office options.
Focus on knowledge sharing and cross-team collaboration, with opportunities to share experiences with one another.
Regular team events to be decided on democratically.
A wonderful and growing company library",
                Location = "Mars, Cave",
                CompanyName = "Social Sweethearts",
                Contact = "mail@me.ch",
                LogoUrl = "https://remoteco.s3.amazonaws.com/wp-content/uploads/2021/06/25114623/social_sweethearts-150x150.png",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
            });

            jobs.Add(new Job
            {
                Title = "C++ Developer at Severalnines",
                JobBody = @"You will work on the backend services for our product ClusterControl which is the leading monitoring and management application for open source databases and used by thousands of companies.

Be part of a great distributed team of highly skilled and motivated colleagues building the next-generation services and applications for database monitoring and management.

Roles & Responsibilities:

5+ years of experience in a software engineering role
Comfortable working from a home office and working independently with remote agile teams
Excellent programming skills in C++ and other functional programming languages. Experience of other programming languages such as BASH, Go, Python, JavaScript is a plus
Strong Linux background and knowledge
Strong debugging and troubleshooting skills
Strong communication and documentation skills
Experience in working with RPC frameworks such as gRPC and developing RESTful APIs with TLS.
Experience of Terraform and Ansible is a plus
Experience writing queries for relational databases (MySQL and PostgreSQL) and distributed document stores such as MongoDB is a plus
Experience in working with containers, VMs, and Cloud services is a plus
Additional Details

We’re a software startup with a globally distributed team. As we don’t have any offices, you will be working remotely; in other words, we all work from our homes. Therefore, a good laptop and access to a reliable, high-speed Internet connection are required. The company is based in Europe and although no travel is required, we do encourage attendance at our annual meeting which rotates cities. Contact us to find out more about the working life at Severalnines!",
                Location = "Remote",
                CompanyName = "Severalnines",
                Contact = "one-job@for.you",
                LogoUrl = "https://remoteco.s3.amazonaws.com/wp-content/uploads/2019/05/severalnines-150x150.jpg",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
            });

            jobs.Add(new Job
            {
                Title = "Full Stack Developer at SixLeaf",
                JobBody = @"About SixLeaf
Originally founded in 2014 as ZonBlast, SixLeaf is the leading marketing platform for Brand Owners on Amazon. We offer a suite of launch and re-launch solutions, and a growing suite of ancillary tools that are helping third party sellers launch, grow, scale, and exit physical product brands on Amazon.

With the experience of being central to over 15,000 Brands’ successful launches in 7 years, SixLeaf is the cornerstone of fast-growing Brands. Since our founding in 2014, our team has had a hand in dozens of 8 figure exits, and have been a part of 9 figures of retail-value products sold on Amazon. By helping Brands grow, we’re helping our clients and their families achieve their dreams, and we’re helping to make Amazon a better, more relevant place for consumers to buy on Amazon. Each member of the SixLeaf team shares in the joy and responsibility of making e-commerce better for consumers and Brand Owners alike.

The Team
Our Development and Engineering team is responsible for implementing our Product Team’s and Stakeholders vision. We work to ensure that what is created is valuable to our end users, central to their Brand’s growth, and serves the business goals set forth. As a central team member, you’ll plug into a fully remote, but close-knit team that is full of experts at what we and our clients do. As Engineer, you’ll have a direct hand in shaping SIxLeaf’s – and our industry’s – future at large. You’ll also be at the start what will be our most aggressive growth phase since inception.

About You
As a Senior Full Stack Software Engineer, you’ll obsess over efficient, readable, and scalable code base as central components to SixLeaf’s near-term growth and production of value for our clients. You’ll dive deep into Amazon’s Partner Seller API, other third party APIs, and help dial in our own API. You’ll design, test, and operate features and tools that will go out to our user base for immediate implementation into our users’ Brands.

You’re a self-starter and team player who embraces challenges and has a track record of overcoming roadblocks and issues. We’re looking for a leader who can act as a multiplier who helps make others around them better and who has the potential – if not already has – led a small team of developers. We’re looking for a true software lead who has a genuine interest in making an impact, both on our team as well as with our clients.

Key Responsibilities Include
Participate in daily standups to maintain high performance
Design, build, test, and operate key systems, APIs, and databases that will be responsible for driving much of SixLeaf’s near-term expansion
Contribute to adding functionality and features to our platform to help Brand Owners scale faster and more efficiently on Amazon
Work closely with the Product Team and stakeholders to bring ideas to life
Collaborate with Product & Design Team to ensure pixel-perfect features and tools are brought to life
Partner with other engineers – both in-house and contracted – to build the roadmap of new ideas and improvements
Contribute to the Engineering team’s efforts to establish and implement best practices
Monitor, analyze, and improve key metrics within the organization
Train and mentor junior engineers
What Your Bring to the Team
3+ years of work experience
Strong skills in jscript, C#, vue.js, mvc, node.js, jquery, Microsoft SQL, and ASP.net
Experience with continuous integration, test automation, and deployment
Experience with architecture design and best practices
Experience with API design and best practices
Familiarity with Agile practices
Superior English written and verbal skills
Exposure to modern front end development tech (vue.js)
Outstanding communication skills involving identification of complex problems, analysis of resolutions, and presentation of same to stakeholders and other team members
Strong work ethic and unassailable honesty and integrity
Self-motivated and agile
Nice To Haves
Bachelor’s in CS, Engineering, or equivalent work experience
Expert level vue.js and c# skills
Experience working with Amazon Partner or MWS APIs
Experience with Microsoft environment (visual studio, team services, sql), Slack, Asana, Product Board
Sound Like You?
To apply, submit your resume, your linkedin profile, and cover letter explaining why you’re the team player we’re in need of. While we won’t be able to apply to every applicant, if we feel like you’re a potential fit, we’ll be in touch within 3-5 business days. SixLeaf is an equal opportunity employer and considers all qualified applicants without regard to race, color, gender, religion, age, etc. No agency resumes please.",
                Location = "Remote",
                CompanyName = "SixLeaf",
                Contact = "013633556478, SixLeaf@fake.fr",
                LogoUrl = "https://remoteco.s3.amazonaws.com/wp-content/uploads/2021/06/14145119/SixLeaf-150x150.png",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
            });

            jobs.Add(new Job
            {
                Title = "Senior Backend Engineer – Collaboration and Reporting Infrastructure",
                JobBody = @"Senior Backend Engineer – Collaboration and Reporting Infrastructure

Location: US National
Remote, United States
Core Engineering
About the team

Collaboration and Reporting Infrastructure (CRI) is an engineering-only team and one of four teams within the Media Cloud Engineering group. CRI builds and maintains scalable infrastructure to support collaboration and reporting use cases across the diverse and complex set of workflows required by the content production and promotion process. Our services free up application engineering teams to enable innovation in the content production space, provide a seamless experience to their business stakeholders and make accurate information available to help inform business decisions. Enabling effective collaboration among business users and artists is critical to our success.

The Media Cloud Engineering (MCE) group provides highly available infrastructure for content production and processing across all Netflix productions and licensed content. Infrastructure pieces like massive scale media processing platforms (1, 2), workflows (conductor), media asset management, collaboration, reporting, data processing are some of the key services we build. All this is custom built on top of Amazon Web Services (AWS) infrastructure.

About the role

We are looking for a senior backend engineer to help us maintain and improve our current suite of products and build the future of collaboration solutions for our stakeholders and business users. In this role you will have the opportunity to drive direction, own development end-to-end, manage stakeholder relationships, provide actionable feedback and insights to colleagues, and create technical solutions at scale. We are looking for a problem solver that delivers maintainable, performant and predictable experiences.

You’ll be successful in this role if you:

Enjoy collaborating with teammates and technical partners across functional teams and have excellent communication skills
Take end-to-end ownership of major features and components: from inception to deployment
Have strong demonstrable knowledge in Backend languages (ex. Java, Go, Python, Ruby)
Build testable, highly-available applications and services with monitoring and alerting
Have a good understanding of concepts like concurrency, parallelism, event driven architecture
Experience with REST-ful APIs for internal and external products
Passionate about teaching and empowering your colleagues and stakeholders
Bonus

Experience with technologies like Spring, Cassandra, Redis, Kafka, Elasticsearch
Building cloud applications (ex. AWS, Google Cloud, Microsoft Azure)",
                Location = "NY, USA",
                CompanyName = "Netflix",
                Contact = "hr@fake.job",
                LogoUrl = "https://remoteco.s3.amazonaws.com/wp-content/uploads/2019/07/30144933/netflix-150x150.jpg",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
            });

            jobs.Add(new Job
            {
                Title = "Senior Manager, Backend Engineering",
                JobBody = @"Life360 is a Remote First company, which means a remote work environment will be the primary experience for all employees. All positions, unless otherwise specified, can be performed remotely (within the US) regardless of any specified location above.

About Life360

Life360 is on a mission to bring families closer and that starts with ensuring that loved ones are safe and secure. That’s why millions of families across 140 countries trust Life360 to keep them connected each day, and in life’s unpredictable moments.

From real-time location sharing and notifications to driving safety features like Crash Detection and Roadside Assistance, we create tools that remove uncertainty from modern life so families can feel free, together.

About the Job

You’ll be leading software engineering teams, taking a platform that ingests 30+ billion locations weekly with subsecond latency to the next level of scale, resilience, and flexibility. You thrive on the agility of a midsize public company that has demonstrated product leadership at consumer web scale. The role is primarily about people leadership, including mentoring technical leaders and overseeing projects. You are credible with engineers, executives, and cross-functional stakeholders. You can teach and learn from the best.

What You’ll Do

Attract, grow, and promote top engineers
Oversee prioritization, definition, planning, and execution of projects
Set ambitious objectives and key results, grounded in practical execution
Coordinate work across engineering, operations, and disciplines
Mentor or manage other people leaders
Build further upon a culture of technical and management excellence
What We’re Looking For

Bachelor’s degree or equivalent
Strong technical roots in hands-on development of complex system software; depth being more important than breadth
Ability to engage with technical leaders designing distributed systems at scale
Operated as a manager and/or engineer during periods of fast business growth
7+ years of progressive experience being directly employed to develop software in products being sold to consumers or their enterprise customers
5+ years of formal management experience including performance appraisals
Strong listening skills and pithy articulation
Detail orientation and informed bias-to-action
Experience in multi-office management, ideally including offshore
Effective application of broad range of project management tools & techniques
Experience using observability systems to detect and isolate faults
Building high-availability systems, and handling incident response when they fail
Experience using or building modern developer tooling and service deployment
Experience evolving from monolithic servers to distributed services
Experience working with delivering and/or consuming services from partners
Experience in application software security
Experience working with a sensor network of mobile and/or IoT devices
Proficiency in Java and one dynamically-typed language
Proficiency in AWS or other public clouds
We value having a diverse and inclusive community from many backgrounds, so even if you don’t meet 100% of the above qualifications, you should still seriously consider applying!

Our Benefits

Competitive pay and benefits
Medical, dental, vision, life and disability insurance plans (100% paid for employees)
401(k) plan with company matching program
Employee Assistance Program (EAP) for mental wellness.
Flexible PTO and 12 company wide days off throughout the year
Learning & Development programs
Equipment, tools, and reimbursement support for a productive remote environment
Free Life360 Platinum Membership for your preferred circle
Life360 Values

Our company’s mission driven culture is guided by our shared values to create a trusted work environment where you can bring your authentic self to work and make a positive difference

Build A High Performing Team Communicate Directly, Be a Good Person
Make Things Happen Take Ownership, Think Long Term
Deliver an Exceptional Experience Users Come First, Quality & Craftsmanship
Our Commitment to Diversity

We believe that different ideas, perspectives and backgrounds create a stronger and more creative work environment that delivers better results. Together, we continue to build an inclusive culture that encourages, supports, and celebrates the diverse voices of our employees. It fuels our innovation and connects us closer to our customers and the communities we serve. We strive to create a workplace that reflects the communities we serve and where everyone feels empowered to bring their authentic best selves to work.

We are an equal opportunity employer and value diversity at Life360. We do not discriminate on the basis of race, religion, color, national origin, gender, sexual orientation, age, marital status, veteran status, disability status or any legally protected status.

We encourage people of all backgrounds to apply. We believe that a diversity of perspectives and experiences create a foundation for the best ideas. Come join us in building something meaningful.

#LI-Remote

Since the majority of our staff is located on the US West Coast, our primary working hours will be 9-4pm PST",
                Location = "Atina, Greece",
                CompanyName = "Life360",
                Contact = "life360@gosho.bg",
                LogoUrl = "https://remoteco.s3.amazonaws.com/wp-content/uploads/2018/10/life_360-150x150.jpeg",
                UserId = "6b4f487f-5cde-4509-825b-103b69220131",
            });

            await dbContext.AddRangeAsync(jobs);
        }
    }
}
