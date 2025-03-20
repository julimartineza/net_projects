using System.Collections;
using System.Collections.Generic;
using UCR.ECCI.PI.frontend.Domain.Value_Objects;
using UCR.ECCI.PI.frontend.Unity.Domain;

namespace UCR.ECCI.PI.frontend.Unity.Infrastructure
{
    public class WhiteboardRepository : IWhiteboardRepository
    {
        private Whiteboard _whiteboard;

        public WhiteboardRepository()
        {
            // Inicializamos la instancia de Whiteboard con valores predeterminados.
            _whiteboard = new Whiteboard("false", "Pizarra", new Scale(1, 1, 1), new Rotation(0, 0, 0, 0), new Location(0, 0, 0), "Lab 4-6");
        }

        // Cambia el estado de en uso a no en uso y viceversa
        public void ChangeStatus()
        {
            _whiteboard.StatusWhiteboard = !_whiteboard.StatusWhiteboard; // Invierte el estado actual
        }

        // Retorna si la pizarra esta en uso o no
        public bool IsOn()
        {
            return _whiteboard.StatusWhiteboard;
        }
    }
}