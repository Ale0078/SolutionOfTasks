using System;
using NLog;

using FirstTask.Messages;
using Task_Logic.Logic.Components.Interfaces;
using Task_Logic.UserInterface.Components.Abstracts;

namespace FirstTask.Controllers
{
    public class BoardController<T> : Controller<T>
    {
        private ILogger _logger;

        public BoardController(View<T> viewToDisplayBoard, IBoardBuilder<T> builderToCreateBoard) 
            : base(viewToDisplayBoard, builderToCreateBoard)
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public override bool AddBoard()
        {
            ViewToDispayBoard.ViewModelsToContainBoards.AddBoard(BuildBoard());

            _logger.Info(LoggerMessage.ADD_BOARD);

            return true;
        }

        public override IBoard<T> BuildBoard()
        {
            try
            {
                return BuilderToCreateBoard.Create();
            }
            finally 
            {
                _logger.Info(LoggerMessage.BUILD_BOARD);
            }
        }

        public override void SetBoardToBuilder(IBoardBuilder<T> boardBuilder)
        {
            BuilderToCreateBoard = boardBuilder;

            _logger.Info(LoggerMessage.SET_BOARD_TO_BUILDER);
        }

        public override void Display()
        {
            if (!ViewToDispayBoard.Display()) 
            {
                _logger.Error(LoggerMessage.DISPLAY_ERROR);
                throw new InvalidOperationException();
            }

            _logger.Info(LoggerMessage.DISPLAY);
        }
    }
}
