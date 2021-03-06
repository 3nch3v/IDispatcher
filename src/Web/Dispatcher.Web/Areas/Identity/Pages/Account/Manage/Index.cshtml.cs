namespace Dispatcher.Web.Areas.Identity.Pages.Account.Manage
{
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Threading.Tasks;

    using Dispatcher.Data.Models;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.Infrastructure;
    using Dispatcher.Web.Infrastructure.CustomAttributes;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    using static Dispatcher.Common.GlobalConstants.User;

    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IProfilesService profileServices;
        private readonly IWebHostEnvironment environment;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IProfilesService profileServices,
            IWebHostEnvironment environment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.profileServices = profileServices;
            this.environment = environment;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (user == null)
            {
                return this.NotFound($"{UnableToLoadUser} '{this.userManager.GetUserId(this.User)}'.");
            }

            await this.LoadAsync(user);

            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (user == null)
            {
                return this.NotFound($"{UnableToLoadUser} '{this.userManager.GetUserId(this.User)}'.");
            }

            if (!this.ModelState.IsValid)
            {
                await this.LoadAsync(user);

                return this.Page();
            }

            var phoneNumber = await this.userManager.GetPhoneNumberAsync(user);

            if (this.Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await this.userManager.SetPhoneNumberAsync(user, this.Input.PhoneNumber);

                if (!setPhoneResult.Succeeded)
                {
                    this.StatusMessage = PhoneError;
                    return this.RedirectToPage();
                }
            }

            var firstName = user.FirstName;
            var lastName = user.LastName;
            var education = user.Education;
            var companyName = user.CompanyName;
            var interests = user.Interest;
            var contacts = user.Contact;
            var websiteUrl = user.WebsiteUrl;
            var githubUrl = user.GithubUrl;
            var facebookUrl = user.FacebookUrl;
            var instagramUrl = user.InstagramUrl;

            if (this.Input.FirstName != firstName)
            {
                user.FirstName = this.Input.FirstName;
            }

            if (this.Input.LastName != lastName)
            {
                user.LastName = this.Input.LastName;
            }

            if (this.Input.Education != education)
            {
                user.Education = this.Input.Education;
            }

            if (this.Input.ComponyName != companyName)
            {
                user.CompanyName = this.Input.ComponyName;
            }

            if (this.Input.Interest != interests)
            {
                user.Interest = this.Input.Interest;
            }

            if (this.Input.Contact != contacts)
            {
                user.Contact = this.Input.Contact;
            }

            if (this.Input.WebsiteUrl != websiteUrl)
            {
                user.WebsiteUrl = this.Input.WebsiteUrl;
            }

            if (this.Input.GithubUrl != githubUrl)
            {
                user.GithubUrl = this.Input.GithubUrl;
            }

            if (this.Input.FacebookUrl != facebookUrl)
            {
                user.FacebookUrl = this.Input.FacebookUrl;
            }

            if (this.Input.InstagramUrl != instagramUrl)
            {
                user.InstagramUrl = this.Input.InstagramUrl;
            }

            if (this.Input.UploadPicture != null)
            {
                string picturePath = $"{this.environment.WebRootPath}{ProfilePicturePath}";

                await this.profileServices.SetProfilePictureAsync(
                         user.Id,
                         await FormFileExtensions.GetBytesAsync(this.Input.UploadPicture),
                         Path.GetExtension(this.Input.UploadPicture.FileName),
                         picturePath);
            }

            await this.userManager.UpdateAsync(user);

            await this.signInManager.RefreshSignInAsync(user);
            this.StatusMessage = UpdatedSuccessfully;

            return this.RedirectToPage();
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await this.userManager.GetUserNameAsync(user);
            var phoneNumber = await this.userManager.GetPhoneNumberAsync(user);
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var education = user.Education;
            var companyName = user.CompanyName;
            var interest = user.Interest;
            var contact = user.Contact;
            var websiteUrl = user.WebsiteUrl;
            var githubUrl = user.GithubUrl;
            var facebookUrl = user.FacebookUrl;
            var instagramUrl = user.InstagramUrl;
            var picture = this.profileServices.GetProfilePicturePath(user.Id);
            this.Username = userName;

            this.Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName = firstName,
                LastName = lastName,
                Education = education,
                ComponyName = companyName,
                Interest = interest,
                Contact = contact,
                WebsiteUrl = websiteUrl,
                GithubUrl = githubUrl,
                FacebookUrl = facebookUrl,
                InstagramUrl = instagramUrl,
                ProfilePicture = picture,
            };
        }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "First name")]
            [StringLength(50, MinimumLength = 2)]
            public string FirstName { get; set; }

            [Display(Name = "Last name")]
            [StringLength(50, MinimumLength = 2)]
            public string LastName { get; set; }

            [StringLength(50, MinimumLength = 2)]
            public string Education { get; set; }

            [Display(Name = "Company name")]
            [StringLength(50, MinimumLength = 2)]
            public string ComponyName { get; set; }

            [Display(Name = "Interests")]
            [StringLength(1000, MinimumLength = 2)]
            public string Interest { get; set; }

            [Display(Name = "Contacts")]
            [StringLength(200, MinimumLength = 6)]
            public string Contact { get; set; }

            [Display(Name = "Website URL")]
            [MaxLength(2048)]
            public string WebsiteUrl { get; set; }

            [Display(Name = "Github")]
            [MaxLength(2048)]
            public string GithubUrl { get; set; }

            [Display(Name = "Facebook")]
            [MaxLength(2048)]
            public string FacebookUrl { get; set; }

            [Display(Name = "Instagram")]
            [MaxLength(2048)]
            public string InstagramUrl { get; set; }

            [Display(Name = "Profile picture")]
            [MaxFileSize(5 * 1024 * 1024)]
            [FileAllowedExtensions(new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" })]
            public IFormFile UploadPicture { get; set; }

            [BindNever]
            public string ProfilePicture { get; set; }
        }
    }
}
