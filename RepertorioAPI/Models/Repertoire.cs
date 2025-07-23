using System;
using System.Collections.Generic;

namespace RepertorioAPI.Models;

public partial class Repertoire
{
    /// <summary>
    /// Identificador do repertório
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nome do repertório
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Data do culto correspondente ao repertório
    /// </summary>
    public DateOnly ServiceDate { get; set; }

    /// <summary>
    /// Data de criação do repertório no sistema
    /// </summary>
    public DateTime CreatedAt { get; set; }

    public virtual ICollection<RepertoireSong> RepertoireSongs { get; set; } = new List<RepertoireSong>();
}
