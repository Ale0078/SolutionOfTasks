using System;
using NLog;

using FirstTask.Messages;
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
        private const int ERROR = -1;

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
                    _logger.Error(LoggerMessage.ADD_BOARD_ERROR);
                }

                ControllerToBoard.Display();
            }
            catch (FormatException ex)
            {
                _logger.Error(LoggerMessage.STARTUP_EXCEPTION, typeof(FormatException), ex.Message);
                Console.WriteLine(ExceptionMessage.EXCEPTION);
            }
            catch (IndexOutOfRangeException ex)
            {
                _logger.Error(LoggerMessage.STARTUP_EXCEPTION, typeof(FormatException), ex.Message);
                Console.WriteLine(ExceptionMessage.EXCEPTION);
            }
            finally 
            {
                _logger.Info(LoggerMessage.STARTUP_FINALY);
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
            int columnRowCount = ConvertColumnCountOrRowCoutnt(columnCountOrRowCount);

            if (CheckColumnCountOrRowCount(columnRowCount))
            {
                return columnRowCount;
            }
            else 
            {
                return ERROR;
            }
        }

        private int ConvertColumnCountOrRowCoutnt(string columnCountOrRowCount) 
        {
            return TransformatorToColumnCountAndRowCount.ConfirmConversion<int, string>(columnCountOrRowCount);
        }

        private bool CheckColumnCountOrRowCount(int columnCountOrRowCount) 
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
