using System;
using System.Collections.Generic;

namespace RepertorioAPI.Models;

public partial class RepertoireSong
{
    /// <summary>
    /// Identificador da associação música/repertório
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ID do repertório associado
    /// </summary>
    public int RepertoireId { get; set; }

    /// <summary>
    /// ID da música associada
    /// </summary>
    public int SongId { get; set; }

    /// <summary>
    /// Ordem da música dentro do repertório
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// Nome do ministro de louvor responsável por cantar a música nesse repertório
    /// </summary>
    public string Minister { get; set; } = null!;

    public virtual Repertoire Repertoire { get; set; } = null!;

    public virtual Song Song { get; set; } = null!;
}
