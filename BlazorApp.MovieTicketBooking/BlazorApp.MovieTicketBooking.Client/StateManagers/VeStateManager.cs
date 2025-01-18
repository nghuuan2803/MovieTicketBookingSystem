using MTBS.Domain.SampleModels;

namespace BlazorApp.MovieTicketBooking.Client.StateManagers
{
    public class VeStateManager
    {
        private readonly Dictionary<int, Ve> _ves = new();
        //public event Action<int, Ve> OnVeStateChanged;
        public Dictionary<int, Action<int, Ve>> KhiVeCapNhat = new();
        private readonly object _lock = new();

        public VeStateManager()
        {
        }
        public void SetData(IEnumerable<Ve> initialVes)
        {
            if (_ves.Count > 0)
                _ves.Clear();
            foreach (var ve in initialVes)
            {
                _ves[ve.Id] = ve;
                //KhiVeCapNhat[ve.Id] = null;
            }
        }

        public Ve GetVe(int veId) => _ves.ContainsKey(veId) ? _ves[veId] : null;

        public void UpdateVeState(int veId, int newStatus, string reservedBy)
        {
            //if (_ves.ContainsKey(veId))
            //{
            //    _ves[veId].TrangThai = newStatus;
            //    _ves[veId].NguoiGiu = reservedBy;
            //    OnVeStateChanged?.Invoke(veId, _ves[veId]);
            //    Console.WriteLine("[VeStateManager]Thread ID: " + Environment.CurrentManagedThreadId);
            //}

            if (_ves.ContainsKey(veId) && KhiVeCapNhat.ContainsKey(veId))
            {
                _ves[veId].TrangThai = newStatus;
                _ves[veId].NguoiGiu = reservedBy;
                KhiVeCapNhat[veId]?.Invoke(veId, _ves[veId]);
            }
        }
        public void AddOrUpdateCallback(int veId, Action<int, Ve> callback)
        {
            //lock (_lock)
            //{
                //if (KhiVeCapNhat.ContainsKey(veId))
                //{
                //    KhiVeCapNhat[veId] += callback;
                //}
                //else
                //{
                    KhiVeCapNhat[veId] = callback;
                //}
            //}
        }
        public IEnumerable<Ve> GetAllSeats() => _ves.Values;
    }

}
