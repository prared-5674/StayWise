using PropertyChanged;
using System.Collections.ObjectModel;
using System.Windows.Input;
using StayWise.Models;
using StayWise.Helpers;

namespace StayWise.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class RoomSelectionViewModel
    {
        public ObservableCollection<Floor> Floors { get; private set; }
        public Room SelectedRoom { get; set; }
        public Bed SelectedBed { get; set; }
        public RoomAllocation SelectedAllocation { get; private set; }

        public ICommand SelectRoomCommand { get; }
        public ICommand SelectBedCommand { get; }
        public ICommand ConfirmSelectionCommand { get; }
        public ICommand CancelCommand { get; }

        public RoomSelectionViewModel()
        {
            InitializeFloors();

            SelectRoomCommand = new RelayCommand<Room>(SelectRoom);
            SelectBedCommand = new RelayCommand<Bed>(SelectBed);
            ConfirmSelectionCommand = new RelayCommand(ConfirmSelection);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void InitializeFloors()
        {
            Floors = new ObservableCollection<Floor>();

            for (int floorNum = 1; floorNum <= 4; floorNum++)
            {
                var floor = new Floor { FloorNumber = floorNum };

                for (int roomNum = 1; roomNum <= 10; roomNum++)
                {
                    var room = new Room
                    {
                        RoomNumber = int.Parse($"{floorNum}{roomNum:D2}"),
                        PricePerBed = 3000 + (floorNum * 500)
                    };

                    // Assign beds based on room number
                    if (roomNum <= 3)
                        room.TotalBeds = 4;
                    else if (roomNum <= 6)
                        room.TotalBeds = 2;
                    else
                        room.TotalBeds = 3;

                    for (int bed = 1; bed <= room.TotalBeds; bed++)
                    {
                        room.Beds.Add(new Bed
                        {
                            BedNumber = bed,
                            IsOccupied = false // In real app, check DB
                        });
                    }

                    floor.Rooms.Add(room);
                }

                Floors.Add(floor);
            }
        }

        private void SelectRoom(Room room)
        {
            if (SelectedRoom != null)
                SelectedRoom.IsSelected = false;

            room.IsSelected = true;
            SelectedRoom = room;
            SelectedBed = null;
        }

        private void SelectBed(Bed bed)
        {
            if (bed.IsOccupied)
                return;

            if (SelectedBed != null)
                SelectedBed.IsSelected = false;

            bed.IsSelected = true;
            SelectedBed = bed;
        }

        private bool CanConfirmSelection()
        {
            return SelectedRoom != null && SelectedBed != null;
        }

        private void ConfirmSelection()
        {
            SelectedAllocation = new RoomAllocation
            {
                FloorNumber = int.Parse(SelectedRoom.RoomNumber.ToString()),
                RoomNumber = SelectedRoom.RoomNumber,
                BedNumber = 1,
                IsSelected = true,
                Amount = SelectedRoom.PricePerBed
            };

           // Close dialog with true result
            CloseDialogWithResult(true);
        }

        private void Cancel()
        {
            CloseDialogWithResult(false);
        }

        private void CloseDialogWithResult(bool result)
        {
            RequestClose?.Invoke(result);
        }

        public event Action<bool> RequestClose;
    }
}