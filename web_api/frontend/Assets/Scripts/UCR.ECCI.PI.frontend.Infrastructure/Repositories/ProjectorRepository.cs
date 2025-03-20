using System.Collections;
using System.Collections.Generic;
using UCR.ECCI.PI.frontend.Domain.Value_Objects;
using UCR.ECCI.PI.frontend.Unity.Domain;

namespace UCR.ECCI.PI.frontend.Unity.Infrastructure
{
    public class ProjectorRepository : IProjectorRepository
    {
        private Projector _projector;

        public ProjectorRepository()
        {
            // Inicializamos la instancia de Tv con valores predeterminados.
            _projector = new Projector("false", "LCD", new Scale(1, 1, 1), new Rotation(0, 0, 0, 0), new Location(0, 0, 0), "Lab 4-6");
        }

        // Cambia el estado de encendido/apagado de la TV
        public void ChangeStatus()
        {
            _projector.ProjectorStatus = !_projector.ProjectorStatus; // Invierte el estado actual
        }

        // Retorna si la TV está encendida
        public bool IsOn()
        {
            return _projector.ProjectorStatus;
        }
    }
}
