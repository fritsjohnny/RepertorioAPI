using System;
using System.Collections.Generic;

namespace RepertorioAPI.Models;

public partial class Song
{
    /// <summary>
    /// Identificador da música
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Título da música
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Cantor ou intérprete da música (opcional)
    /// </summary>
    public string? Artist { get; set; }

    /// <summary>
    /// Tom da música (ex: C, D#, F#m)
    /// </summary>
    public string? Key { get; set; }

    /// <summary>
    /// Andamento da música (Lento, Médio, Rápido)
    /// </summary>
    public string? Tempo { get; set; }

    /// <summary>
    /// Tema principal (Adoração, Guerra, Ceia, etc.)
    /// </summary>
    public string? Theme { get; set; }

    /// <summary>
    /// Letra completa da música (opcional)
    /// </summary>
    public string? Lyrics { get; set; }

    /// <summary>
    /// Tags ou palavras-chave associadas à música
    /// </summary>
    public string? Tags { get; set; }

    /// <summary>
    /// Link externo para a música (ex: YouTube, Spotify, etc.)
    /// </summary>
    public string? ExternalLink { get; set; }

    /// <summary>
    /// Referências bíblicas relacionadas à música (ex: João 3:16, Salmo 126)
    /// </summary>
    public string? BibleReferences { get; set; }

    /// <summary>
    /// Tipo de louvor: Adoração ou Celebração
    /// </summary>
    public string WorshipType { get; set; } = null!;

    public virtual ICollection<RepertoireSong> RepertoireSongs { get; set; } = new List<RepertoireSong>();
}
