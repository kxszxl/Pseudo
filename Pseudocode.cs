namespace Test
{
    public class Controller
    {
        
        public static void OnCommand(Keys keycode)
        {
            if (keycode == Keys.NumPad0)
            {
                if (!Data.isinit)
                {
                    
                }
            }
        }
    }
    //■※□＠１２３ＡＢＣ
    public class UI
    {
        
    }
    public class Map
    {
        private static Map _instance;
        public static Map Instance
        {
            get
            {
                if (_instance == null)
                { _instance = new Map(); }
                return _instance;
            }
        }

        public MapData Mdata
        {
            get
            {
                return Data.mdata;
            }
        }
        public void init()
        {
            Mdata.xSize = 5;
            Mdata.ySize = 5;
            Mdata.cells = new CellData[Mdata.xSize, Mdata.ySize];
        }
    }
    public class Player
    {
        private static Player _instance;
        public static Player Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Player();
                }
                return _instance;
            }
        }

        public PlayerData Pdata
        {
            get
            {
                return Data.pdata;
            }
        }
        public void Scan()
        {
            int lx = Math.Max(Pdata.pos.x - Pdata.vision,0);
            int ty = Math.Min(Pdata.pos.y + Pdata.vision, Data.mdata.ySize - 1);
            int rx = Math.Min(Pdata.pos.x + Pdata.vision, Data.mdata.xSize - 1);
            int by = Math.Max(Pdata.pos.y - Pdata.vision, 0);
            for (int y = ty; y >= by; y--)
            {
                for (int x = lx; x <= rx; x++)
                {
                    Pdata.fogs[x, y] = 1;
                    Pdata.looks[Data.mdata.cells[x, y]] = 1;
                }
            }
        }
    }
    /*Data*/
    public static class Data
    {
        public static bool isinit = false;
        public static MapData mdata = new MapData();
        public static List<EnemyData> edatalist = new List<EnemyData>();
        public static PlayerData pdata = new PlayerData();
    }
    public class MapData
    {
        public int xSize;
        public int ySize;
        public CellData[,] cells;
    }
    public class CellData
    {
        public int x;
        public int y;
    }
    public class PlayerData
    {
        public int hp;
        public int atk;
        public int vision;
        public CellData pos;
        public int[,] fogs;
        public Dictionary<CellData, int> looks;
    }
    public class EnemyData
    {
        public int typeid;
        public int hp;
        public int atk;
    }
    /*common*/
    public struct Vec2
    {
        public int x;
        public int y;
        public Vec2(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }
}