using Assignment12.CustomValidators;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace Assignment12.Models
{
    public class Order : IValidatableObject
    {
        public int? OrderNo { get; set; }
        [Required(ErrorMessage = "OrderDate can't be blank")]
        [Range(typeof(DateTime), "1/1/2000", "12/31/2099", ErrorMessage = "Order date must be between 1/1/2000 and 12/31/2099.")]
        public DateTime? OrderDate { get; set; }
        [Required]
        public double? InvoicePrice { get; set; }
        [Required]
        public List<Product> Products { get; set; } = new List<Product>();
        public Order()
        {
            OrderNo = new Random().Next(1, 99999);
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Products == null || Products.Count == 0)
            {
                yield return new ValidationResult(
                    "At least one product must be provided",
                    new[] { nameof(Products) });
            }
            double totalPrice = Products.Sum(p => (p.Price ?? 0) * (p.Quantity ?? 0));
            if (InvoicePrice != totalPrice)
            {
                yield return new ValidationResult(
                    "InvoicePrice doesn't match with the total cost of the specified products in the order",
                    new[] { nameof(InvoicePrice) });
            }
            for (int i = 0; i < Products.Count; i++)
            {
                var product = Products[i];

                // Validate the product object
                var results = new List<ValidationResult>();
                var context = new ValidationContext(product);
                bool isValid = Validator.TryValidateObject(product, context, results, true);

                foreach (var validationResult in results)
                {
                    // Format nested field names
                    var memberNames = validationResult.MemberNames
                        .Select(m => $"Products[{i}].{m}");
                    yield return new ValidationResult(validationResult.ErrorMessage, memberNames);
                }
            }
        }
    }
}
