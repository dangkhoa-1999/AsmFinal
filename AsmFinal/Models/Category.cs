using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsmFinal.Models
{

    public class Category
    {

        public int Id { get; set; }

        [Required]
        [DisplayName("Category Name")]
        [StringLength(50)]
        [Remote("IsProductNameExist", "Category", AdditionalFields = "Id",
                ErrorMessage = "Product name already exists")]
        public string Name { get; set; }


    } }

