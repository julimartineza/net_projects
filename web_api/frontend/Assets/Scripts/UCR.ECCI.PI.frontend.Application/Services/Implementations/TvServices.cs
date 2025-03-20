using UCR.ECCI.PI.frontend.Unity.Domain;

namespace UCR.ECCI.PI.frontend.Unity.Application.Implementations
{
    public class TvServices : ITvService
    {
        private readonly ITvRepository _tv;

        public TvServices(ITvRepository tv)
        {
            _tv = tv;
        }

        public void ChangeStatus()
        {
            _tv.ChangeStatus(); 
        }
        
        public bool IsOn()
        {
            return _tv.IsOn();
        }
    }
}
