using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;
using ColumnAttribute = Supabase.Postgrest.Attributes.ColumnAttribute;
using PrimaryKeyAttribute = Supabase.Postgrest.Attributes.PrimaryKeyAttribute;
using TableAttribute = Supabase.Postgrest.Attributes.TableAttribute;

namespace APIRestIndotInventarioMovil.Models
{
    [Table("usuarios")]
    public class Usuario: BaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }
        [Column("empresa")]
        public string Empresa { get; set; }
        [Column("codEmpresa")]
        public string CodEmpresa { get; set; }
        [Column("token")]
        public string? Token { get; set; }
    }
}

