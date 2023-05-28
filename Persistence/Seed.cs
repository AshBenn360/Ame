using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {

            if(!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser{DisplayName = "Ash", UserName= "ash", Email="ashleysbennett@icloud.com"}
                };

                foreach(var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }

            if(!context.ApplicationInformationDetails.Any())
            {
                var appInfo = new AppInformation{
                    BackendFramework = "Microsoft Web Api",
                    Pattern = "CQRS"
                };

                context.ApplicationInformationDetails.Add(appInfo);
            }

            if(!context.PackagingConditions.Any())
            {
                var listPackagingConditions = new List<PackagingCondition>();

                listPackagingConditions.Add(new PackagingCondition{
                    Description = "Wood Crated",
                    DisplayOrder = 1,
                });

                 listPackagingConditions.Add(new PackagingCondition{
                    Description = "Not Packed",
                    DisplayOrder = 2,
                });

                 listPackagingConditions.Add(new PackagingCondition{
                    Description = "Soft Wrapped",
                    DisplayOrder = 3,
                });

                foreach (var packingCondition in listPackagingConditions)
                {
                    context.PackagingConditions.Add(packingCondition);
                }
            }

                if(!context.SpecialRequirements.Any())
            {
                var listSpecialRequirements = new List<SpecialRequirement>();

                listSpecialRequirements.Add(new SpecialRequirement{
                    Description = "2 Person Delivery",
                    DisplayOrder = 1,
                });

                 listSpecialRequirements.Add(new SpecialRequirement{
                    Description = "White Glove Delivery",
                    DisplayOrder = 2,
                });

                 listSpecialRequirements.Add(new SpecialRequirement{
                    Description = "Delivered Up 1 Flight of Stairs",
                    DisplayOrder = 3,
                });

                foreach (var specialRequirement in listSpecialRequirements)
                {
                    context.SpecialRequirements.Add(specialRequirement);
                }
            }

                   if(!context.QuotationStatuses.Any())
            {
                var listQuotationStatuses = new List<QuotationStatus>();

                listQuotationStatuses.Add(new QuotationStatus{
                    Name = "Confirmed",
                    Order = 1,
                });

                 listQuotationStatuses.Add(new QuotationStatus{
                    Name = "Arrived",
                    Order = 2,
                });

                 listQuotationStatuses.Add(new QuotationStatus{
                    Name = "Dispatched",
                    Order = 3,
                });

                 listQuotationStatuses.Add(new QuotationStatus{
                    Name = "Finished",
                    Order = 4,
                });

                 listQuotationStatuses.Add(new QuotationStatus{
                    Name = "Cancelled",
                    Order = 5,
                });

                 listQuotationStatuses.Add(new QuotationStatus{
                    Name = "UnLoading",
                    Order = 6,
                });

                foreach (var quotationStatus in listQuotationStatuses)
                {
                    context.QuotationStatuses.Add(quotationStatus);
                }
            }


            
            await context.SaveChangesAsync();
        }
    }
}