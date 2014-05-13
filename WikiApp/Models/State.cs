using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WikiApp.Models;
using System.ComponentModel.DataAnnotations;

namespace WikiApp.Models
{
    public enum State
    {
        Request = 1, 
        Edit, 
        Ready
    }
}