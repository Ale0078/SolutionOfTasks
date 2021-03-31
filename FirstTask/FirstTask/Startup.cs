using System;
using NLog;

using FirstTask.Controllers;
using FirstTask.Views;
using FirstTask.ViewModels;
using Task_Logic.Logic.Components.Builders;
using Task_Logic.Logic.Components.Builders.Abstracts;
using Task_Logic.UserInterface.Components.Abstracts;
using LibToTasks.Validation;

namespace FirstTask
{
    public class Startup<T>
    {
        private const int MAX_BOARD_SIZE = 100;
        private const int MIN_BOARD_SIZE = 2;

        private ILogger _logger;

        private Controller<T> ControllerToBoard { get; set; }
        private Validator ValidatorToRowCountAndColumnCount { get; set; }
        private Transformator TransformatorToColumnCountAndRowCount { get; set; }

        private string[] Args { get; set; }
        private T[] ValuesToSetCells { get; set; }

        public Startup(string[] args, params T[] valuesToSetCells)
        {
            _logger = LogManager.GetCurrentClassLogger();
            ValidatorToRowCountAndColumnCount = new Validator();
            TransformatorToColumnCountAndRowCount = new Transformator();

            Args = args;
            ValuesToSetCells = valuesToSetCells;
        }

        public void Start()
        {
            try
            {
                ControllerToBoard = new BoardController<T>(
                viewToDisplayBoard: CreateView(CreateViewModels()),
                builderToCreateBoard: CreateBuilder(
                    columnCount: GetColumnCountOrRowCount(Args[0]),
                    rowCount: GetColumnCountOrRowCount(Args[1]),
                    valuesToSetCells: ValuesToSetCells));

                if (!ControllerToBoard.AddBoard())
                {
                    _logger.Error("Board was not added to ViewModels");
                }

                ControllerToBoard.Display();
            }
            catch (FormatException ex)
            {
                _logger.Error("Program finalize with exception: {0}, messange: {1}", typeof(FormatException), ex.Message);
                Console.WriteLine("Please, enter a count of column like int and a count of row like int too.\n" +
                    "Both numbers must be no more than 99 and no less than 3.");
            }
            catch (IndexOutOfRangeException ex)
            {
                _logger.Error("Program finalize with exception: {0}, messange: {1}", typeof(FormatException), ex.Message);
                Console.WriteLine("Please, enter a count of column like int and a count of row like int too.\n" +
                    "Both numbers must be no more than 99 and no less than 3.");
            }
            finally 
            {
                _logger.Info("Program was finished");
            }
        }

        private BoardBuilder<T> CreateBuilder(int columnCount, int rowCount, params T[] valuesToSetCells)
        {
            return new ChessBoardBuilder<T>(columnCount, rowCount, valuesToSetCells);
        }

        private View<T> CreateView(ViewModels<T> viewModelsToContainsBoard)
        {
            return new ConsoleView<T>(viewModelsToContainsBoard);
        }

        private ViewModels<T> CreateViewModels()
        {
            return new ConsoleViewModel<T>();
        }

        private int GetColumnCountOrRowCount(string columnCountOrRowCount) 
        {
            return CheckColumnCountOrRowCount(
                columnCountOrRowCount: ConvertColumnCountOrRowCoutnt(columnCountOrRowCount));
        }

        private int ConvertColumnCountOrRowCoutnt(string columnCountOrRowCount) 
        {
            return TransformatorToColumnCountAndRowCount.ConfirmConversion<int, string>(columnCountOrRowCount);
        }

        private int CheckColumnCountOrRowCount(int columnCountOrRowCount) 
        {
            return ValidatorToRowCountAndColumnCount.CheckValue(validator =>
            {
                if (validator > MAX_BOARD_SIZE || validator < MIN_BOARD_SIZE)
                {
                    return false;
                }

                return true;
            }, columnCountOrRowCount, true);
        }
    }
}
