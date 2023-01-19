using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTB.Eshop.Domain.Implementation.Validations
{
    //[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.Field)]
    public class FileSizeAttribute : ValidationAttribute, IClientModelValidator
    {
        public long ContentMaxSize { get; set; }
        public FileSizeAttribute(uint contentMaxSize)
        {
            ContentMaxSize = contentMaxSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {


            if (value == null)
            {
                return ValidationResult.Success;
            }

            var file = value as IFormFile;

            if (file == null)
            {
                throw new NotImplementedException($"The file is not IMAGE!");
            }

            if (file.Length > ContentMaxSize)
            {
                return new ValidationResult($"File size is too big. Max allowed size is {ContentMaxSize}bytes!");
            }

            return ValidationResult.Success;

        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-size", "true");
            context.Attributes.Add("data-val-filesize", $"{context.ModelMetadata.Name}: max file size is {ContentMaxSize} bytes!");
            context.Attributes.Add("data-val-filesize-size", ContentMaxSize.ToString());
        }
    }
}