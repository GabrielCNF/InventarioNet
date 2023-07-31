using System;
using System.Collections.Generic;

namespace InventarioNet.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nome { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public int Ativo { get; set; }

    public string? Email { get; set; }
}
