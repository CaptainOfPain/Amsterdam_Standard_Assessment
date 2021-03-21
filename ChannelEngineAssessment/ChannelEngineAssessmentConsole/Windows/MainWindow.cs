using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChannelEngineAssessmentConsole.Models;
using ChannelEngineAssessmentInfrastructure;
using ChannelEngineAssessmentInfrastructure.Products.Commands;
using ChannelEngineAssessmentInfrastructure.Products.DTOs;
using ChannelEngineAssessmentInfrastructure.Products.Queries;
using ChannelEngineAssessmentShared.Application.Handlers.Abstraction;
using Terminal.Gui;

namespace ChannelEngineAssessmentConsole.Windows
{
    public class MainWindow : Window
    {
        private readonly ICommandQueryDispatcherDecorator _commandQueryDispatcherDecorator;
        private readonly IMapper _mapper;

        public ListView ListView;
        private IEnumerable<TopSoldProductTerminalModel> _topSoldProducts = new List<TopSoldProductTerminalModel>();

        public MainWindow(ICommandQueryDispatcherDecorator commandQueryDispatcherDecorator, IMapper mapper)
        {
            _commandQueryDispatcherDecorator = commandQueryDispatcherDecorator ?? throw new ArgumentNullException(nameof(commandQueryDispatcherDecorator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            InitializeView();
        }

        private async void InitializeView()
        {
            await SetTopSoldProductsAsync();
            await InitializeControlsAsync();
        }

        private async Task InitializeControlsAsync()
        {
            var listViewFrame = new FrameView("Top sold products")
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Percent(80),
            };
            ListView = new ListView()
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill(),
            };
            await ListView.SetSourceAsync(_topSoldProducts.ToList());
            listViewFrame.Add(ListView);

            var button = new Button()
            {
                Text = "Set stock to 25",
                X = 0,
                Y = Pos.Bottom(listViewFrame)
            };

            button.Clicked += async () => await ChangeSelectedProductStockAsync();

            Add(listViewFrame, button);
        }

        private async Task ChangeSelectedProductStockAsync()
        {
            var selectedProduct = _topSoldProducts.ToArray()[ListView.SelectedItem];
            var command = new SetProductStockCommand(selectedProduct.MerchantProductNo, 25);

            await _commandQueryDispatcherDecorator.DispatchAsync(command);

            await SetTopSoldProductsAsync();
        }

        private async Task SetTopSoldProductsAsync()
        {
            _topSoldProducts = await GetTopSoldProductsAsync();
        }

        private async Task<IEnumerable<TopSoldProductTerminalModel>> GetTopSoldProductsAsync()
        {
            var query = new GetTopSoldProductsQuery();
            var productsList = await _commandQueryDispatcherDecorator.DispatchAsync<GetTopSoldProductsQuery, ListResultDto<TopSoldProductDto>>(query);

            return _mapper.Map<IEnumerable<TopSoldProductTerminalModel>>(productsList.Items);
        }
    }
}
