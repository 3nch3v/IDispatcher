namespace Dispatcher.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Models.BlogModels;
    using Microsoft.Extensions.Configuration;

    public class BlogsSeeder : ISeeder
    {
        public async Task SeedAsync(
            ApplicationDbContext dbContext,
            IServiceProvider serviceProvider,
            IConfiguration configuration)
        {
            if (dbContext.Blogs.Any())
            {
                return;
            }

            var blogs = new List<Blog>
            {
                new Blog
                {
                    Title = $"CSS",
                    Body = @"Cascading Style Sheets (CSS) is a style sheet language used for describing the presentation of a document written in a markup language such as HTML.[1] CSS is a cornerstone technology of the World Wide Web, alongside HTML and JavaScript.[2]

CSS is designed to enable the separation of presentation and content, including layout, colors, and fonts.[3] This separation can improve content accessibility, provide more flexibility and control in the specification of presentation characteristics, enable multiple web pages to share formatting by specifying the relevant CSS in a separate .css file which reduces complexity and repetition in the structural content as well as enabling the .css file to be cached to improve the page load speed between the pages that share the file and its formatting.

Separation of formatting and content also makes it feasible to present the same markup page in different styles for different rendering methods, such as on-screen, in print, by voice (via speech-based browser or screen reader), and on Braille-based tactile devices. CSS also has rules for alternate formatting if the content is accessed on a mobile device.[4]

The name cascading comes from the specified priority scheme to determine which style rule applies if more than one rule matches a particular element. This cascading priority scheme is predictable.

The CSS specifications are maintained by the World Wide Web Consortium (W3C). Internet media type (MIME type) text/css is registered for use with CSS by RFC 2318 (March 1998). The W3C operates a free CSS validation service for CSS documents.[5]

In addition to HTML, other markup languages support the use of CSS including XHTML, plain XML, SVG, and XUL.
Syntax
CSS has a simple syntax and uses a number of English keywords to specify the names of various style properties.

A style sheet consists of a list of rules. Each rule or rule-set consists of one or more selectors, and a declaration block.

Selector
In CSS, selectors declare which part of the markup a style applies to by matching tags and attributes in the markup itself.

Selectors may apply to the following:

all elements of a specific type, e.g. the second-level headers h2
elements specified by attribute, in particular:
id: an identifier unique within the document, identified with a hash prefix e.g. #id
class: an identifier that can annotate multiple elements in a document, identified with a period prefix e.g. .classname
elements depending on how they are placed relative to others in the document tree.
Classes and IDs are case-sensitive, start with letters, and can include alphanumeric characters, hyphens, and underscores. A class may apply to any number of instances of any elements. An ID may only be applied to a single element.

Pseudo-classes are used in CSS selectors to permit formatting based on information that is not contained in the document tree. One example of a widely used pseudo-class is :hover, which identifies content only when the user ""points to"" the visible element, usually by holding the mouse cursor over it. It is appended to a selector as in a:hover or #elementid:hover. A pseudo-class classifies document elements, such as :link or :visited, whereas a pseudo-element makes a selection that may consist of partial elements, such as ::first-line or ::first-letter.[6]

Selectors may be combined in many ways to achieve great specificity and flexibility.[7] Multiple selectors may be joined in a spaced list to specify elements by location,
                element type,
                id, class, or any combination thereof.The order of the selectors is important.For example, div.myClass { color: red; }
        applies to all elements of class myClass that are inside div elements, whereas.myClass div { color: red; }
        applies to all div elements that are inside elements of class myClass. This is not to be confused with concatenated identifiers such as div.myClass {color: red;}
    which applies to div elements of class myClass.

The following table provides a summary of selector syntax indicating usage and the version of CSS that introduced it.[8]",
                    FilePath = "/img/blog-pictures/CSS3_logo_and_wordmark.svg",
                    Extension = ".png",
                    UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
                },
                new Blog
                {
                    Title = $"What is Computer Science?",
                    Body = @"Computer Science is the study of computers and computational systems. Unlike electrical and computer engineers, computer scientists deal mostly with software and software systems; this includes their theory, design, development, and application.

Principal areas of study within Computer Science include artificial intelligence, computer systems and networks, security, database systems, human computer interaction, vision and graphics, numerical analysis, programming languages, software engineering, bioinformatics and theory of computing.

Although knowing how to program is essential to the study of computer science, it is only one element of the field. Computer scientists design and analyze algorithms to solve programs and study the performance of computer hardware and software. The problems that computer scientists encounter range from the abstract-- determining what problems can be solved with computers and the complexity of the algorithms that solve them – to the tangible – designing applications that perform well on handheld devices, that are easy to use, and that uphold security measures.

Graduates of University of Maryland’s Computer Science Department are lifetime learners; they are able to adapt quickly with this challenging field.",
                    UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
                },
                new Blog
                {
                    Title = $"PC Motherboard",
                    Body = @"A motherboard (also called mainboard, main circuit board,[1] or mobo) is the main printed circuit board (PCB) in general-purpose computers and other expandable systems. It holds and allows communication between many of the crucial electronic components of a system, such as the central processing unit (CPU) and memory, and provides connectors for other peripherals. Unlike a backplane, a motherboard usually contains significant sub-systems, such as the central processor, the chipset's input/output and memory controllers, interface connectors, and other components integrated for general use.

Motherboard means specifically a PCB with expansion capabilities. As the name suggests, this board is often referred to as the ""mother"" of all components attached to it, which often include peripherals, interface cards, and daughtercards: sound cards, video cards, network cards, host bus adapters, TV tuner cards, IEEE 1394 cards; and a variety of other custom components.

Dell Precision T3600 System Motherboard,
                used in professional CAD Workstations.Manufactured in 2012
Similarly,
                the term mainboard describes a device with a single board and no additional expansions or capability,
                such as controlling boards in laser printers,
                television sets,
                washing machines,
                mobile phones,
                and other embedded systems with limited expansion abilities.
History
Prior to the invention of the microprocessor, the digital computer consisted of multiple printed circuit boards in a card-cage case with components connected by a backplane, a set of interconnected sockets. In very old designs, copper wires were the discrete connections between card connector pins, but printed circuit boards soon became the standard practice. The central processing unit (CPU), memory, and peripherals were housed on individually printed circuit boards, which were plugged into the backplane. The ubiquitous S-100 bus of the 1970s is an example of this type of backplane system.

The most popular computers of the 1980s such as the Apple II and IBM PC had published schematic diagrams and other documentation which permitted rapid reverse-engineering and third-party replacement motherboards. Usually intended for building new computers compatible with the exemplars, many motherboards offered additional performance or other features and were used to upgrade the manufacturer's original equipment.

During the late 1980s and early 1990s, it became economical to move an increasing number of peripheral functions onto the motherboard. In the late 1980s, personal computer motherboards began to include single ICs (also called Super I/O chips) capable of supporting a set of low-speed peripherals: PS/2 keyboard and mouse, floppy disk drive, serial ports, and parallel ports. By the late 1970s, many personal computer motherboards included consumer-grade embedded audio, video, storage, and networking functions without the need for any expansion cards at all; higher-end systems for 3D gaming and computer graphics typically retained only the graphics card as a separate component. Business PCs, workstations, and servers were more likely to need expansion cards, either for more robust functions, or for higher speeds; those systems often had fewer embedded components.

Laptop and notebook computers that were developed in the 1990s integrated the most common peripherals. This even included motherboards with no upgradeable components, a trend that would continue as smaller systems were introduced after the turn of the century (like the tablet computer and the netbook). Memory, processors, network controllers, power source, and storage would be integrated into some systems.",
                    FilePath = "/img/blog-pictures/Vlb",
                    Extension = ".jpg",
                    UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
                },
                new Blog
                {
                    Title = $"History of general-purpose CPUs",
                    Body = @"1950s: Early designs

A Vacuum tube module from early 700 series IBM computers
In the early 1950s, each computer design was unique. There were no upward-compatible machines or computer architectures with multiple, differing implementations. Programs written for one machine would run on no other kind, even other kinds from the same company. This was not a major drawback then because no large body of software had been developed to run on computers, so starting programming from scratch was not seen as a large barrier.

The design freedom of the time was very important because designers were very constrained by the cost of electronics, and only starting to explore how a computer could best be organized. Some of the basic features introduced during this period included index registers (on the Ferranti Mark 1), a return address saving instruction (UNIVAC I), immediate operands (IBM 704), and detecting invalid operations (IBM 650).

By the end of the 1950s, commercial builders had developed factory-constructed, truck-deliverable computers. The most widely installed computer was the IBM 650, which used drum memory onto which programs were loaded using either paper punched tape or punched cards. Some very high-end machines also included core memory which provided higher speeds. Hard disks were also starting to grow popular.

A computer is an automatic abacus. The type of number system affects the way it works. In the early 1950s, most computers were built for specific numerical processing tasks, and many machines used decimal numbers as their basic number system; that is, the mathematical functions of the machines worked in base-10 instead of base-2 as is common today. These were not merely binary-coded decimal (BCD). Most machines had ten vacuum tubes per digit in each processor register. Some early Soviet computer designers implemented systems based on ternary logic; that is, a bit could have three states: +1, 0, or -1, corresponding to positive, zero, or negative voltage.

An early project for the U.S. Air Force, BINAC attempted to make a lightweight, simple computer by using binary arithmetic. It deeply impressed the industry.

As late as 1970, major computer languages were unable to standardize their numeric behavior because decimal computers had groups of users too large to alienate.

Even when designers used a binary system, they still had many odd ideas. Some used sign-magnitude arithmetic (-1 = 10001), or ones' complement (-1 = 11110), rather than modern two's complement arithmetic (-1 = 11111). Most computers used six-bit character sets because they adequately encoded Hollerith punched cards. It was a major revelation to designers of this period to realize that the data word should be a multiple of the character size. They began to design computers with 12-, 24- and 36-bit data words (e.g., see the TX-2).

In this era, Grosch's law dominated computer design: computer cost increased as the square of its speed.

1960s: Computer revolution and CISC
One major problem with early computers was that a program for one would work on no others. Computer companies found that their customers had little reason to remain loyal to a given brand, as the next computer they bought would be incompatible anyway. At that point, the only concerns were usually price and performance.

In 1962, IBM tried a new approach to designing computers. The plan was to make a family of computers that could all run the same software, but with different performances, and at different prices. As users' needs grew, they could move up to larger computers, and still keep all of their investment in programs, data and storage media.

To do this, they designed one reference computer named System/360 (S/360). This was a virtual computer, a reference instruction set, and abilities that all machines in the family would support. To provide different classes of machines, each computer in the family would use more or less hardware emulation, and more or less microprogram emulation, to create a machine able to run the full S/360 instruction set.

For instance, a low-end machine could include a very simple processor for low cost. However this would require the use of a larger microcode emulator to provide the rest of the instruction set, which would slow it down. A high-end machine would use a much more complex processor that could directly process more of the S/360 design, thus running a much simpler and faster emulator.

IBM chose consciously to make the reference instruction set quite complex, and very capable. Even though the computer was complex, its control store holding the microprogram would stay relatively small, and could be made with very fast memory. Another important effect was that one instruction could describe quite a complex sequence of operations. Thus the computers would generally have to fetch fewer instructions from the main memory, which could be made slower, smaller and less costly for a given mix of speed and price.

As the S/360 was to be a successor to both scientific machines like the 7090 and data processing machines like the 1401, it needed a design that could reasonably support all forms of processing. Hence the instruction set was designed to manipulate simple binary numbers, and text, scientific floating-point (similar to the numbers used in a calculator), and the binary-coded decimal arithmetic needed by accounting systems.

Almost all following computers included these innovations in some form. This basic set of features is now called complex instruction set computing (CISC, pronounced ""sisk""), a term not invented until many years later, when reduced instruction set computing (RISC) began to get market share.

In many CISCs,
                an instruction could access either registers or memory,
                usually in several different ways.This made the CISCs easier to program,
                because a programmer could remember only thirty to a hundred instructions,
                and a set of three to ten addressing modes rather than thousands of distinct instructions.This was called an orthogonal instruction set.The PDP - 11 and Motorola 68000 architecture are examples of nearly orthogonal instruction sets.

There was also the BUNCH(Burroughs, UNIVAC, NCR, Control Data Corporation, and Honeywell) that competed against IBM at this time; however, IBM dominated the era with S/ 360.

The Burroughs Corporation(which later merged with Sperry / Univac to form Unisys) offered an alternative to S / 360 with their Burroughs large systems B5000 series.In 1961, the B5000 had virtual memory, symmetric multiprocessing, a multiprogramming operating system(Master Control Program (MCP)), written in ALGOL 60, and the industry's first recursive-descent compilers as early as 1964.

Late 1960s–early 1970s: LSI and microprocessors
The MOSFET(metal-oxide-semiconductor field-effect transistor), also known as the MOS transistor, was invented by Mohamed Atalla and Dawon Kahng at Bell Labs in 1959, and demonstrated in 1960. This led to the development of the metal-oxide-semiconductor(MOS) integrated circuit(IC), proposed by Kahng in 1961, and fabricated by Fred Heiman and Steven Hofstein at RCA in 1962.[1] With its high scalability,[2] and much lower power consumption and higher density than bipolar junction transistors,[3] the MOSFET made it possible to build high-density integrated circuits.[4][5] Advances in MOS integrated circuit technology led to the development of large-scale integration(LSI) chips in the late 1960s and eventually the invention of the microprocessor in the early 1970s.[6]

In the 1960s, the development of electronic calculators, electronic clocks, the Apollo guidance computer, and Minuteman missile, helped make MOS integrated circuits economical and practical.In the late 1960s, the first calculator and clock chips began to show that very small computers might be possible with large-scale integration (LSI). This culminated in the invention of the microprocessor, a single-chip CPU. The Intel 4004, released in 1971, was the first commercial microprocessor.[7][8] The origins of the 4004 date back to the ""Busicom Project"", [9] which began at Japanese calculator company Busicom in April 1968, when engineer Masatoshi Shima was tasked with designing a special-purpose LSI chipset, along with his supervisor Tadashi Tanba, for use in the Busicom 141-PF desktop calculator with integrated printer.[10][11] His initial design consisted of seven LSI chips, including a three-chip CPU.[9] His design included arithmetic units (adders), multiplier units, registers, read-only memory, and a macro-instruction set to control a decimal computer system.[10] Busicom then wanted a general-purpose LSI chipset, for not only desktop calculators, but also other equipment such as a teller machine, cash register and billing machine.Shima thus began work on a general-purpose LSI chipset in late 1968.[11] Sharp engineer Tadashi Sasaki, who also became involved with its development, conceived of a single-chip microprocessor in 1968, when he discussed the concept at a brainstorming meeting that was held in Japan.Sasaki attributes the basic invention to break the calculator chipset into four parts with ROM (4001), RAM(4002), shift registers(4003) and CPU(4004) to an unnamed woman, a software engineering researcher from Nara Women's College, who was present at the meeting. Sasaki then had his first meeting with Robert Noyce from Intel in 1968, and presented the woman's four-division chipset concept to Intel and Busicom.[12]

Busicom approached the American company Intel for manufacturing help in 1969. Intel, which primarily manufactured memory at the time, had facilities to manufacture the high density silicon gate MOS chip Busicom required.[11] Shima went to Intel in June 1969 to present his design proposal.Due to Intel lacking logic engineers to understand the logic schematics or circuit engineers to convert them, Intel asked Shima to simplify the logic.[11] Intel wanted a single-chip CPU design,[11] influenced by Sharp's Tadashi Sasaki who presented the concept to Busicom and Intel in 1968.[12] The single-chip microprocessor design was then formulated by Intel's Marcian ""Ted"" Hoff in 1969,[9] simplifying Shima's initial design down to four chips, including a single-chip CPU.[9] Due to Hoff's formulation lacking key details, Shima came up with his own ideas to find solutions for its implementation.Shima was responsible for adding a 10-bit static shift register to make it useful as a printer's buffer and keyboard interface, many improvements in the instruction set, making the RAM organization suitable for a calculator, the memory address information transfer, the key program in an area of performance and program capacity, the functional specification, decimal computer idea, software, desktop calculator logic, real-time I/O control, and data exchange instruction between the accumulator and general purpose register. Hoff and Shima eventually realized the 4-bit microprocessor concept together, with the help of Intel's Stanley Mazor to interpret the ideas of Shima and Hoff.[11] The specifications of the four chips were developed over a period of a few months in 1969, between an Intel team led by Hoff and a Busicom team led by Shima.[9]

In late 1969, Shima returned to Japan.[11] After that, Intel had done no further work on the project until early 1970.[11][9] Shima returned to Intel in early 1970, and found that no further work had been done on the 4004 since he left, and that Hoff had moved on to other projects.[11] Only a week before Shima had returned to Intel, [11] Federico Faggin had joined Intel and become the project leader.[9] After Shima explained the project to Faggin, they worked together to design the 4004.[11] Thus, the chief designers of the chip were Faggin who created the design methodology and the silicon-based chip design, Hoff who formulated the architecture before moving on to other projects, and Shima who produced the initial Busicom design and then assisted in the development of the final Intel design.[10] The 4004 was first introduced in Japan, as the microprocessor for the Busicom 141-PF calculator, in March 1971.[11][10] In North America, the first public mention of the 4004 was an advertisement in the November 15, 1971 edition of Electronic News.[13]

NEC released the μPD707 and μPD708, a two-chip 4-bit CPU, in 1971.[14] They were followed by NEC's first single-chip microprocessor, the μPD700, in April 1972.[15][16] It was a prototype for the μCOM-4 (μPD751), released in April 1973,[15] combining the μPD707 and μPD708 into a single microprocessor.[14] In 1973, Toshiba released the TLCS-12, the first 12-bit microprocessor.[15][17]",
                    VideoLink = @"<iframe width=""640"" height =""480"" src =""https://www.youtube.com/embed/iSKGVncs_ZQ"" title =""YouTube video player"" frameborder =""0"" allow =""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"" allowfullscreen ></iframe>",
                    UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
                },
                new Blog
                {
                    Title = $"Become a Software DeveloperLearn to code and start your career",
                    Body = @"Our story
SoftUni is an award - winning educational IT institution providing training and career support in the field of software engineering,
                digital marketing and creative.

SoftUni was founded in 2013 to pursue the mission to build a global organization which provides practical,
                quality and accessible education in the area of digital and information technologies,
                creating real experts and future leaders.Today,
                we partner with more than 200 IT companies and have an active community of 200 000 students.On our training catalog,
                you can find professional programs,
                courses,
                and open lessons to meet your learning needs.
Our Educational Model
The main principle of our educational model is “learning by doing” and the practical approach in an essential part of the teaching methodology. We aim for our students to acquire real practical skills that they will need to get hired or advance in their career.

The self-paced learning model allows the students to learn with their own pace and a schedule that works best for them. Self-paced learning is suitable for different learning styles and allows the students to access study materials at their own pace which means they can focus on things that they find challenging.",
                    FilePath = "/img/blog-pictures/Logo_Software_University_(SoftUni)_-_blue",
                    Extension = ".png",
                    VideoLink = @"<iframe width=""853"" height =""480"" src =""https://www.youtube.com/embed/nrSlqAb4ZLw"" title =""YouTube video player"" frameborder =""0"" allow =""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"" allowfullscreen ></iframe>",
                    UserId = "6b4f487f-5cde-4509-825b-103b69220131",
                },
                new Blog
                {
                    Title = $"Why choose ASP.NET Core?",
                    Body = @"Millions of developers use or have used ASP.NET 4.x to create web apps. ASP.NET Core is a redesign of ASP.NET 4.x, including architectural changes that result in a leaner, more modular framework.

ASP.NET Core provides the following benefits:

A unified story for building web UI and web APIs.
Architected for testability.
Razor Pages makes coding page-focused scenarios easier and more productive.
Blazor lets you use C# in the browser alongside JavaScript. Share server-side and client-side app logic all written with .NET.
Ability to develop and run on Windows, macOS, and Linux.
Open-source and community-focused.
Integration of modern, client-side frameworks and development workflows.
Support for hosting Remote Procedure Call (RPC) services using gRPC.
A cloud-ready, environment-based configuration system.
Built-in dependency injection.
A lightweight, high-performance, and modular HTTP request pipeline.
Ability to host on the following:
Kestrel
IIS
HTTP.sys
Nginx
Apache
Docker
Side-by-side versioning.
Tooling that simplifies modern web development.

Build web APIs and web UI using ASP.NET Core MVC
ASP.NET Core MVC provides features to build web APIs and web apps:

The Model-View-Controller (MVC) pattern helps make your web APIs and web apps testable.
Razor Pages is a page-based programming model that makes building web UI easier and more productive.
Razor markup provides a productive syntax for Razor Pages and MVC views.
Tag Helpers enable server-side code to participate in creating and rendering HTML elements in Razor files.
Built-in support for multiple data formats and content negotiation lets your web APIs reach a broad range of clients, including browsers and mobile devices.
Model binding automatically maps data from HTTP requests to action method parameters.
Model validation automatically performs client-side and server-side validation.
Client-side development
ASP.NET Core integrates seamlessly with popular client-side frameworks and libraries, including Blazor, Angular, React, and Bootstrap. For more information, see Introduction to ASP.NET Core Blazor and related topics under Client-side development.


ASP.NET Core target frameworks
ASP.NET Core 3.x and later can only target .NET Core. Generally, ASP.NET Core is composed of .NET Standard libraries. Libraries written with .NET Standard 2.0 run on any .NET platform that implements .NET Standard 2.0.

There are several advantages to targeting .NET Core, and these advantages increase with each release. Some advantages of .NET Core over .NET Framework include:

Cross-platform. Runs on Windows, macOS, and Linux.
Improved performance
Side-by-side versioning
New APIs
Open source",
                    VideoLink = @"<iframe width=""914"" height=""514"" src =""https://www.youtube.com/embed/C5cnZ-gZy2I"" title =""YouTube video player"" frameborder =""0"" allow =""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"" allowfullscreen ></iframe>",
                    FilePath = "/img/blog-pictures/asp-net",
                    Extension = ".png",
                    UserId = "6b4f487f-5cde-4509-825b-103b69220131",
                },
                new Blog
                {
                    Title = $"Was ist C#?",
                    Body = @"Was ist C#?
C# ist eine objektorientierte universell einsetzbare Programmiersprache. C# zeichnet sich durch eine starke Typisierung und Konzepte, die an Java, C/C++ sowie Delphi angelehnt sind, aus. Die von Microsoft entwickelte Programmiersprache integriert sich in das .NET Ökosystem und ermöglicht so Cross-Plattform Entwicklung für Anwendungen auf Windows, macOS und Linux sowie Web Applikationen. Eine umfangreiche Klassenbibliothek unterstützt beispielsweise TCP/IP-Socket-Programmierung, die Erstellung grafischer Oberflächen und Schnittstellen für Web-Applikationen.
Wann zählt soXes auf C#?
Die universelle Einsetzbarkeit und die grosse Klassenbibliothek machen C# zur Allround-Technologie. Bei soXes nutzen wir C# in allen Bereichen, wo Agilität und eine breite Palette an Möglichkeiten gefragt sind. Dank dem .NET Ökosystem kann soXes mit C# Desktop-, Server- und Webapplikationen oder auch REST APIs erstellen. Dies vereinfacht beispielsweise die Implementation, wenn eine Web-, sowie auch eine Desktopversion notwendig sind. Bei soXes greifen wir z.B. auch bei der Modernisierung von Delphi Software oft auf ein Technologiebündel aus C#, ASP.NET und SQL-Server zurück, um so die Software auf die neuesten technologischen Standards zu aktualisieren und den Usern via Browser zur Verfügung zu stellen.
Wo hat soXes C# eingesetzt?
soXes setzt C# sehr häufig in Projekten ein. Wir konnten beispielsweise im Auftrag der Wilux Print AG ein Reengineering einer bestehenden Delphi Software durchführen. Bei diesem Projekt haben wir durch die Migration von Delphi auf C# eine Modernisierung der bestehenden Druck-, Scan- und Etikettierlösung für grosse Produktionsanlagen vorgenommen. Des Weiteren haben wir mit TESTEX ULU ein komplettes ERP-System zur Unterstützung sämtlicher Abläufe von der Auftragserteilung und -planung bis hin zur Durchführung und Reportierung von chemischen und physikalischen Qualitätstests bei Textilien umgesetzt. Die Lösung ist seit 2016 im Einsatz und wird kontinuierlich von soXes weiterentwickelt.
Warum soXes?
Mit soXes gewinnen Sie einen Partner mit Kompetenz und Verlässlichkeit. Unser Unternehmen steht bereits seit 20 Jahren für beste Qualität in der Entwicklung, Programmierung und dem Outsourcing von Software. Mit ihren Dienstleistungen deckt soXes den gesamten Lebenszyklus einer IT-Entwicklung (Konzeption, Beratung, Entwicklung und Support) ab. Nehmen Sie den ersten Schritt zur erfolgreichen Umsetzung Ihres Projekts und kontaktieren Sie uns für weitere Informationen.",
                    FilePath = "/img/blog-pictures/c-sharp",
                    Extension = ".png",
                    VideoLink = @"<iframe width=""853"" height=""480"" src =""https://www.youtube.com/embed/qOruiBrXlAw"" title =""YouTube video player"" frameborder =""0"" allow =""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"" allowfullscreen ></iframe>",
                    UserId = "6b4f487f-5cde-4509-825b-103b69220131",
                },
                new Blog
                {
                    Title = $"JavaScript",
                    Body = @"JavaScript (/ˈdʒɑːvəˌskrɪpt/),[8] often abbreviated as JS, is a programming language that conforms to the ECMAScript specification.[9] JavaScript is high-level, often just-in-time compiled, and multi-paradigm. It has curly-bracket syntax, dynamic typing, prototype-based object-orientation, and first-class functions.

Alongside HTML and CSS, JavaScript is one of the core technologies of the World Wide Web.[10] Over 97% of websites use it client-side for web page behavior,[11] often incorporating third-party libraries.[12] All major web browsers have a dedicated JavaScript engine to execute the code on the user's device.

As a multi-paradigm language, JavaScript supports event-driven, functional, and imperative programming styles. It has application programming interfaces (APIs) for working with text, dates, regular expressions, standard data structures, and the Document Object Model (DOM).

The ECMAScript standard does not include any input/output (I/O), such as networking, storage, or graphics facilities. In practice, the web browser or other runtime system provides JavaScript APIs for I/O.

JavaScript engines were originally used only in web browsers, but they are now core components of other software systems, most notably servers and a variety of applications.

Although there are similarities between JavaScript and Java, including language name, syntax, and respective standard libraries, the two languages are distinct and differ greatly in design.",
                    FilePath = "/img/blog-pictures/javascript_logo_unofficial",
                    Extension = ".png",
                    UserId = "6b4f487f-5cde-4509-825b-103b69220131",
                },
                new Blog
                {
                    Title = $"Java is Dying - Stop Using and Teaching It",
                    Body = @"I just completed the color effects module for REPL.it (so students forced to code in Java at schools that require it can at least incorporate color into their text-based projects, which compile slower than all the other languages so far, by the way) and was reminded of just how bad Java syntax is. Then I tried to quickly download Java onto a system here to compile a class. I had to go to Oracle’s site where I got to read this rant about NPAPI support being dropped in Chrome including the very serious recommendation that I drop Chrome (hands down the leading web browser) and use MSIE (not Edge) or Safari (pfffhahaha) instead:
Then I researched the state of NPAPI and all the problems with it. That was when I read that Microsoft has dropped all NPAPI support in Internet Explorer since 5.5 and none in Edge “for security reasons.” From the way Oracle describes it in their statement you would think that Chrome and Google were doing a bad thing by dropping something that “has been supported by all major web browsers for over a decade.”
The sheer cluelessness Oracle demonstrates in that statement is astounding.
Oracle Won Against Google
Oracle (like all dying companies that cannot keep up on competitive merit) is following in SCO’s footsteps as the modern patent-troll suing Google literally months after buying Sun Microsystems based on violation of what Sun promised the world would remain an open Java API. Here’s the terrifying part, Oracle recently won on appeal. This has chilling consequences since it means that people can sue after releasing “open APIs” and encouraging people to use and critically adopt them, that the API definition itself is proprietary and carries licensing considerations where no license-granting vehicles exist.
Why would any organization want to encourage this let alone place themselves at real risk of becoming an Oracle target?
Java is the Modern COBOL
At the risk of offending many amazing Java and COBOL programmers I am going to suggest that Java—despite it’s descending but high TIOBE ranking and core place within Android—is dead technology. The strict single inheritance model has been widely viewed as a bloated failure even by the language’s creators.
JVM Still Risky
Clojure and other modern languages leverage the deployed JVMs of enterprises to maintain some sense of modern architecture, but they maintain a core dependency on Java and Oracle. Most organizations simply do not see the danger this poses.",
                    FilePath = "/img/blog-pictures/0fc51f82e036e1d3",
                    Extension = ".jpg",
                    UserId = "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb",
                },
                new Blog
                {
                    Title = $"History of general-purpose CPUs",
                    Body = @"1950s: Early designs

A Vacuum tube module from early 700 series IBM computers
In the early 1950s, each computer design was unique. There were no upward-compatible machines or computer architectures with multiple, differing implementations. Programs written for one machine would run on no other kind, even other kinds from the same company. This was not a major drawback then because no large body of software had been developed to run on computers, so starting programming from scratch was not seen as a large barrier.

The design freedom of the time was very important because designers were very constrained by the cost of electronics, and only starting to explore how a computer could best be organized. Some of the basic features introduced during this period included index registers (on the Ferranti Mark 1), a return address saving instruction (UNIVAC I), immediate operands (IBM 704), and detecting invalid operations (IBM 650).

By the end of the 1950s, commercial builders had developed factory-constructed, truck-deliverable computers. The most widely installed computer was the IBM 650, which used drum memory onto which programs were loaded using either paper punched tape or punched cards. Some very high-end machines also included core memory which provided higher speeds. Hard disks were also starting to grow popular.

A computer is an automatic abacus. The type of number system affects the way it works. In the early 1950s, most computers were built for specific numerical processing tasks, and many machines used decimal numbers as their basic number system; that is, the mathematical functions of the machines worked in base-10 instead of base-2 as is common today. These were not merely binary-coded decimal (BCD). Most machines had ten vacuum tubes per digit in each processor register. Some early Soviet computer designers implemented systems based on ternary logic; that is, a bit could have three states: +1, 0, or -1, corresponding to positive, zero, or negative voltage.

An early project for the U.S. Air Force, BINAC attempted to make a lightweight, simple computer by using binary arithmetic. It deeply impressed the industry.

As late as 1970, major computer languages were unable to standardize their numeric behavior because decimal computers had groups of users too large to alienate.

Even when designers used a binary system, they still had many odd ideas. Some used sign-magnitude arithmetic (-1 = 10001), or ones' complement (-1 = 11110), rather than modern two's complement arithmetic (-1 = 11111). Most computers used six-bit character sets because they adequately encoded Hollerith punched cards. It was a major revelation to designers of this period to realize that the data word should be a multiple of the character size. They began to design computers with 12-, 24- and 36-bit data words (e.g., see the TX-2).

In this era, Grosch's law dominated computer design: computer cost increased as the square of its speed.

1960s: Computer revolution and CISC
One major problem with early computers was that a program for one would work on no others. Computer companies found that their customers had little reason to remain loyal to a given brand, as the next computer they bought would be incompatible anyway. At that point, the only concerns were usually price and performance.

In 1962, IBM tried a new approach to designing computers. The plan was to make a family of computers that could all run the same software, but with different performances, and at different prices. As users' needs grew, they could move up to larger computers, and still keep all of their investment in programs, data and storage media.

To do this, they designed one reference computer named System/360 (S/360). This was a virtual computer, a reference instruction set, and abilities that all machines in the family would support. To provide different classes of machines, each computer in the family would use more or less hardware emulation, and more or less microprogram emulation, to create a machine able to run the full S/360 instruction set.

For instance, a low-end machine could include a very simple processor for low cost. However this would require the use of a larger microcode emulator to provide the rest of the instruction set, which would slow it down. A high-end machine would use a much more complex processor that could directly process more of the S/360 design, thus running a much simpler and faster emulator.

IBM chose consciously to make the reference instruction set quite complex, and very capable. Even though the computer was complex, its control store holding the microprogram would stay relatively small, and could be made with very fast memory. Another important effect was that one instruction could describe quite a complex sequence of operations. Thus the computers would generally have to fetch fewer instructions from the main memory, which could be made slower, smaller and less costly for a given mix of speed and price.

As the S/360 was to be a successor to both scientific machines like the 7090 and data processing machines like the 1401, it needed a design that could reasonably support all forms of processing. Hence the instruction set was designed to manipulate simple binary numbers, and text, scientific floating-point (similar to the numbers used in a calculator), and the binary-coded decimal arithmetic needed by accounting systems.

Almost all following computers included these innovations in some form. This basic set of features is now called complex instruction set computing (CISC, pronounced ""sisk""), a term not invented until many years later, when reduced instruction set computing (RISC) began to get market share.

In many CISCs,
                an instruction could access either registers or memory,
                usually in several different ways.This made the CISCs easier to program,
                because a programmer could remember only thirty to a hundred instructions,
                and a set of three to ten addressing modes rather than thousands of distinct instructions.This was called an orthogonal instruction set.The PDP - 11 and Motorola 68000 architecture are examples of nearly orthogonal instruction sets.

There was also the BUNCH(Burroughs, UNIVAC, NCR, Control Data Corporation, and Honeywell) that competed against IBM at this time; however, IBM dominated the era with S/ 360.

The Burroughs Corporation(which later merged with Sperry / Univac to form Unisys) offered an alternative to S / 360 with their Burroughs large systems B5000 series.In 1961, the B5000 had virtual memory, symmetric multiprocessing, a multiprogramming operating system(Master Control Program (MCP)), written in ALGOL 60, and the industry's first recursive-descent compilers as early as 1964.

Late 1960s–early 1970s: LSI and microprocessors
The MOSFET(metal-oxide-semiconductor field-effect transistor), also known as the MOS transistor, was invented by Mohamed Atalla and Dawon Kahng at Bell Labs in 1959, and demonstrated in 1960. This led to the development of the metal-oxide-semiconductor(MOS) integrated circuit(IC), proposed by Kahng in 1961, and fabricated by Fred Heiman and Steven Hofstein at RCA in 1962.[1] With its high scalability,[2] and much lower power consumption and higher density than bipolar junction transistors,[3] the MOSFET made it possible to build high-density integrated circuits.[4][5] Advances in MOS integrated circuit technology led to the development of large-scale integration(LSI) chips in the late 1960s and eventually the invention of the microprocessor in the early 1970s.[6]

In the 1960s, the development of electronic calculators, electronic clocks, the Apollo guidance computer, and Minuteman missile, helped make MOS integrated circuits economical and practical.In the late 1960s, the first calculator and clock chips began to show that very small computers might be possible with large-scale integration (LSI). This culminated in the invention of the microprocessor, a single-chip CPU. The Intel 4004, released in 1971, was the first commercial microprocessor.[7][8] The origins of the 4004 date back to the ""Busicom Project"", [9] which began at Japanese calculator company Busicom in April 1968, when engineer Masatoshi Shima was tasked with designing a special-purpose LSI chipset, along with his supervisor Tadashi Tanba, for use in the Busicom 141-PF desktop calculator with integrated printer.[10][11] His initial design consisted of seven LSI chips, including a three-chip CPU.[9] His design included arithmetic units (adders), multiplier units, registers, read-only memory, and a macro-instruction set to control a decimal computer system.[10] Busicom then wanted a general-purpose LSI chipset, for not only desktop calculators, but also other equipment such as a teller machine, cash register and billing machine.Shima thus began work on a general-purpose LSI chipset in late 1968.[11] Sharp engineer Tadashi Sasaki, who also became involved with its development, conceived of a single-chip microprocessor in 1968, when he discussed the concept at a brainstorming meeting that was held in Japan.Sasaki attributes the basic invention to break the calculator chipset into four parts with ROM (4001), RAM(4002), shift registers(4003) and CPU(4004) to an unnamed woman, a software engineering researcher from Nara Women's College, who was present at the meeting. Sasaki then had his first meeting with Robert Noyce from Intel in 1968, and presented the woman's four-division chipset concept to Intel and Busicom.[12]

Busicom approached the American company Intel for manufacturing help in 1969. Intel, which primarily manufactured memory at the time, had facilities to manufacture the high density silicon gate MOS chip Busicom required.[11] Shima went to Intel in June 1969 to present his design proposal.Due to Intel lacking logic engineers to understand the logic schematics or circuit engineers to convert them, Intel asked Shima to simplify the logic.[11] Intel wanted a single-chip CPU design,[11] influenced by Sharp's Tadashi Sasaki who presented the concept to Busicom and Intel in 1968.[12] The single-chip microprocessor design was then formulated by Intel's Marcian ""Ted"" Hoff in 1969,[9] simplifying Shima's initial design down to four chips, including a single-chip CPU.[9] Due to Hoff's formulation lacking key details, Shima came up with his own ideas to find solutions for its implementation.Shima was responsible for adding a 10-bit static shift register to make it useful as a printer's buffer and keyboard interface, many improvements in the instruction set, making the RAM organization suitable for a calculator, the memory address information transfer, the key program in an area of performance and program capacity, the functional specification, decimal computer idea, software, desktop calculator logic, real-time I/O control, and data exchange instruction between the accumulator and general purpose register. Hoff and Shima eventually realized the 4-bit microprocessor concept together, with the help of Intel's Stanley Mazor to interpret the ideas of Shima and Hoff.[11] The specifications of the four chips were developed over a period of a few months in 1969, between an Intel team led by Hoff and a Busicom team led by Shima.[9]

In late 1969, Shima returned to Japan.[11] After that, Intel had done no further work on the project until early 1970.[11][9] Shima returned to Intel in early 1970, and found that no further work had been done on the 4004 since he left, and that Hoff had moved on to other projects.[11] Only a week before Shima had returned to Intel, [11] Federico Faggin had joined Intel and become the project leader.[9] After Shima explained the project to Faggin, they worked together to design the 4004.[11] Thus, the chief designers of the chip were Faggin who created the design methodology and the silicon-based chip design, Hoff who formulated the architecture before moving on to other projects, and Shima who produced the initial Busicom design and then assisted in the development of the final Intel design.[10] The 4004 was first introduced in Japan, as the microprocessor for the Busicom 141-PF calculator, in March 1971.[11][10] In North America, the first public mention of the 4004 was an advertisement in the November 15, 1971 edition of Electronic News.[13]

NEC released the μPD707 and μPD708, a two-chip 4-bit CPU, in 1971.[14] They were followed by NEC's first single-chip microprocessor, the μPD700, in April 1972.[15][16] It was a prototype for the μCOM-4 (μPD751), released in April 1973,[15] combining the μPD707 and μPD708 into a single microprocessor.[14] In 1973, Toshiba released the TLCS-12, the first 12-bit microprocessor.[15][17]",
                    VideoLink = @"<iframe width=""640"" height =""480"" src =""https://www.youtube.com/embed/iSKGVncs_ZQ"" title =""YouTube video player"" frameborder =""0"" allow =""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"" allowfullscreen ></iframe>",
                    UserId = "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb",
                },
                new Blog
                {
                    Title = $"Become a Software DeveloperLearn to code and start your career",
                    Body = @"Our story
SoftUni is an award - winning educational IT institution providing training and career support in the field of software engineering,
                digital marketing and creative.

SoftUni was founded in 2013 to pursue the mission to build a global organization which provides practical,
                quality and accessible education in the area of digital and information technologies,
                creating real experts and future leaders.Today,
                we partner with more than 200 IT companies and have an active community of 200 000 students.On our training catalog,
                you can find professional programs,
                courses,
                and open lessons to meet your learning needs.
Our Educational Model
The main principle of our educational model is “learning by doing” and the practical approach in an essential part of the teaching methodology. We aim for our students to acquire real practical skills that they will need to get hired or advance in their career.

The self-paced learning model allows the students to learn with their own pace and a schedule that works best for them. Self-paced learning is suitable for different learning styles and allows the students to access study materials at their own pace which means they can focus on things that they find challenging.",
                    FilePath = "/img/blog-pictures/Logo_Software_University_(SoftUni)_-_blue",
                    Extension = ".png",
                    VideoLink = @"<iframe width=""853"" height =""480"" src =""https://www.youtube.com/embed/nrSlqAb4ZLw"" title =""YouTube video player"" frameborder =""0"" allow =""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"" allowfullscreen ></iframe>",
                    UserId = "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb",
                },
                new Blog
                {
                    Title = $"Why choose ASP.NET Core?",
                    Body = @"Millions of developers use or have used ASP.NET 4.x to create web apps. ASP.NET Core is a redesign of ASP.NET 4.x, including architectural changes that result in a leaner, more modular framework.

ASP.NET Core provides the following benefits:

A unified story for building web UI and web APIs.
Architected for testability.
Razor Pages makes coding page-focused scenarios easier and more productive.
Blazor lets you use C# in the browser alongside JavaScript. Share server-side and client-side app logic all written with .NET.
Ability to develop and run on Windows, macOS, and Linux.
Open-source and community-focused.
Integration of modern, client-side frameworks and development workflows.
Support for hosting Remote Procedure Call (RPC) services using gRPC.
A cloud-ready, environment-based configuration system.
Built-in dependency injection.
A lightweight, high-performance, and modular HTTP request pipeline.
Ability to host on the following:
Kestrel
IIS
HTTP.sys
Nginx
Apache
Docker
Side-by-side versioning.
Tooling that simplifies modern web development.

Build web APIs and web UI using ASP.NET Core MVC
ASP.NET Core MVC provides features to build web APIs and web apps:

The Model-View-Controller (MVC) pattern helps make your web APIs and web apps testable.
Razor Pages is a page-based programming model that makes building web UI easier and more productive.
Razor markup provides a productive syntax for Razor Pages and MVC views.
Tag Helpers enable server-side code to participate in creating and rendering HTML elements in Razor files.
Built-in support for multiple data formats and content negotiation lets your web APIs reach a broad range of clients, including browsers and mobile devices.
Model binding automatically maps data from HTTP requests to action method parameters.
Model validation automatically performs client-side and server-side validation.
Client-side development
ASP.NET Core integrates seamlessly with popular client-side frameworks and libraries, including Blazor, Angular, React, and Bootstrap. For more information, see Introduction to ASP.NET Core Blazor and related topics under Client-side development.


ASP.NET Core target frameworks
ASP.NET Core 3.x and later can only target .NET Core. Generally, ASP.NET Core is composed of .NET Standard libraries. Libraries written with .NET Standard 2.0 run on any .NET platform that implements .NET Standard 2.0.

There are several advantages to targeting .NET Core, and these advantages increase with each release. Some advantages of .NET Core over .NET Framework include:

Cross-platform. Runs on Windows, macOS, and Linux.
Improved performance
Side-by-side versioning
New APIs
Open source",
                    VideoLink = @"<iframe width=""914"" height=""514"" src =""https://www.youtube.com/embed/C5cnZ-gZy2I"" title =""YouTube video player"" frameborder =""0"" allow =""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"" allowfullscreen ></iframe>",
                    FilePath = "/img/blog-pictures/asp-net",
                    Extension = ".png",
                    UserId = "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb",
                },
                new Blog
                {
                    Title = $"Was ist C#?",
                    Body = @"Was ist C#?
C# ist eine objektorientierte universell einsetzbare Programmiersprache. C# zeichnet sich durch eine starke Typisierung und Konzepte, die an Java, C/C++ sowie Delphi angelehnt sind, aus. Die von Microsoft entwickelte Programmiersprache integriert sich in das .NET Ökosystem und ermöglicht so Cross-Plattform Entwicklung für Anwendungen auf Windows, macOS und Linux sowie Web Applikationen. Eine umfangreiche Klassenbibliothek unterstützt beispielsweise TCP/IP-Socket-Programmierung, die Erstellung grafischer Oberflächen und Schnittstellen für Web-Applikationen.
Wann zählt soXes auf C#?
Die universelle Einsetzbarkeit und die grosse Klassenbibliothek machen C# zur Allround-Technologie. Bei soXes nutzen wir C# in allen Bereichen, wo Agilität und eine breite Palette an Möglichkeiten gefragt sind. Dank dem .NET Ökosystem kann soXes mit C# Desktop-, Server- und Webapplikationen oder auch REST APIs erstellen. Dies vereinfacht beispielsweise die Implementation, wenn eine Web-, sowie auch eine Desktopversion notwendig sind. Bei soXes greifen wir z.B. auch bei der Modernisierung von Delphi Software oft auf ein Technologiebündel aus C#, ASP.NET und SQL-Server zurück, um so die Software auf die neuesten technologischen Standards zu aktualisieren und den Usern via Browser zur Verfügung zu stellen.
Wo hat soXes C# eingesetzt?
soXes setzt C# sehr häufig in Projekten ein. Wir konnten beispielsweise im Auftrag der Wilux Print AG ein Reengineering einer bestehenden Delphi Software durchführen. Bei diesem Projekt haben wir durch die Migration von Delphi auf C# eine Modernisierung der bestehenden Druck-, Scan- und Etikettierlösung für grosse Produktionsanlagen vorgenommen. Des Weiteren haben wir mit TESTEX ULU ein komplettes ERP-System zur Unterstützung sämtlicher Abläufe von der Auftragserteilung und -planung bis hin zur Durchführung und Reportierung von chemischen und physikalischen Qualitätstests bei Textilien umgesetzt. Die Lösung ist seit 2016 im Einsatz und wird kontinuierlich von soXes weiterentwickelt.
Warum soXes?
Mit soXes gewinnen Sie einen Partner mit Kompetenz und Verlässlichkeit. Unser Unternehmen steht bereits seit 20 Jahren für beste Qualität in der Entwicklung, Programmierung und dem Outsourcing von Software. Mit ihren Dienstleistungen deckt soXes den gesamten Lebenszyklus einer IT-Entwicklung (Konzeption, Beratung, Entwicklung und Support) ab. Nehmen Sie den ersten Schritt zur erfolgreichen Umsetzung Ihres Projekts und kontaktieren Sie uns für weitere Informationen.",
                    FilePath = "/img/blog-pictures/c-sharp",
                    Extension = ".png",
                    VideoLink = @"<iframe width=""853"" height=""480"" src =""https://www.youtube.com/embed/qOruiBrXlAw"" title =""YouTube video player"" frameborder =""0"" allow =""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"" allowfullscreen ></iframe>",
                    UserId = "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb",
                },
            };

            await dbContext.Blogs.AddRangeAsync(blogs);
        }
    }
}
