using System;
using System.Collections.Generic;

namespace RepertorioAPI.Models;

public partial class User
{
    public int Id { get; set; }

    /// <summary>
    /// Nome completo do usuário
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Nome de login do usuário (único)
    /// </summary>
    public string Username { get; set; } = null!;

    /// <summary>
    /// Hash da senha do usuário
    /// </summary>
    public string PasswordHash { get; set; } = null!;

    /// <summary>
    /// Permissão para inserir registros
    /// </summary>
    public bool CanInsert { get; set; }

    /// <summary>
    /// Permissão para editar registros
    /// </summary>
    public bool CanUpdate { get; set; }

    /// <summary>
    /// Permissão para excluir registros
    /// </summary>
    public bool CanDelete { get; set; }

    public DateTime CreatedAt { get; set; }
}
