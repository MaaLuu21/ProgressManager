using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressManager.Entities.Enums
{
    enum Opcoes : int
    {
        // --- Modificar no diagrama de classe
        InserirUsuario = 0,
        InserirMedidas = 1,
        CalcularIMC = 2,
        Progresso = 3,
        ModificarMedida = 4,
        ModificarUsuario = 5,
        RemoverMedida = 6,
        RemoverUsuario = 7,
        Sair = 8
    }
}
