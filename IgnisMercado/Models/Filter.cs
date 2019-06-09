using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPagesIgnis.Models
{

//Crear RazorPagesIgnisContextlkm{}
    public class Filter
    {
        public static IQueryable Filte( RazorPagesIgnis.Models.RazorPagesIgnisContext _context, string SearchString)
        {
        IQueryable<string> genreQuery = from m in _context.Technicians
                                        orderby m.Nivel
                                        select m.Nivel;

        var technician = from m in _context.Technicians
                     select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                technician = technician.Where(s => s.Especialidad.Contains(SearchString));
            }
            return technician;
        }
}

}