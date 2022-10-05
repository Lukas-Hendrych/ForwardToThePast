using Library.Weapons;

namespace GUI {
    public class BtOption : Button {
        string btName;

        public string BtName { get => btName; set => btName = value; }

        public BtOption() {
            Size = new Size(124, 46);
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Consolas", 10F, FontStyle.Bold, GraphicsUnit.Point);
        }

        public BtOption(string btName) {
            Size = new Size(124, 46);
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Consolas", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtName=btName;
        } 
    }
}
