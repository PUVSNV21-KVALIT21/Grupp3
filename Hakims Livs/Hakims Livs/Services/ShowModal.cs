using Blazored.Modal;
using Hakims_Livs.Pages;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;

namespace Hakims_Livs.Services
{
    public interface IShowModal 
    {
        void DisplayModal(int id);
    }
    public class ShowModal : IShowModal
    {   
        private readonly IModalService _modalService;
        public ShowModal(IModalService modal)
        {
            _modalService = modal;
        }

        public void DisplayModal(int productId)
        {
            var parameters = new ModalParameters();
            parameters.Add(nameof(ProductDetails.id), productId);

            _modalService.Show<ProductDetails>(("Product"), parameters);
        }
    }

}
