using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingCard.API.Dtos;
using ShoppingCard.API.Messages;
using ShoppingCard.API.RabbitMQ;
using ShoppingCard.API.Repositories;
using ShoppingCard.API.Services;

namespace ShoppingCard.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/cartc")]
    public class CartAPICheckOutController : ControllerBase
    {

        private readonly ICartRepository _cartRepository;
        private readonly ICouponRepository _couponRepository;
        private readonly IEmailService _emailService;
        // private readonly IMessageBus _messageBus;
        protected ResponseDto _response;
        private readonly IRabbitMQCartMessageSender _rabbitMQCartMessageSender;
        // IMessageBus messageBus,
        public CartAPICheckOutController(
            ICartRepository cartRepository,
            ICouponRepository couponRepository,
            IRabbitMQCartMessageSender rabbitMQCartMessageSender,
            IEmailService emailService
        )
        {
            _cartRepository = cartRepository;
            _couponRepository = couponRepository;
            _rabbitMQCartMessageSender = rabbitMQCartMessageSender;
            _emailService = emailService;
            //_messageBus = messageBus;
            this._response = new ResponseDto();
        }

        [HttpPost]
        [Authorize]
        public async Task<object> Checkout([FromBody] CheckoutHeaderDto checkoutHeader)
        {
            try
            {
                CartDto cartDto = await _cartRepository.GetCartByUserId(checkoutHeader.UserId);
                if (cartDto == null)
                {
                    return BadRequest();
                }

                if (!string.IsNullOrEmpty(checkoutHeader.CouponCode))
                {
                    CouponDto coupon = await _couponRepository.GetCoupon(checkoutHeader.CouponCode);
                    if (checkoutHeader.DiscountTotal != coupon.DiscountAmount)
                    {
                        _response.IsSuccess = false;
                        _response.ErrorMessages = new List<string>() { "Coupon Price has changed, please confirm" };
                        _response.DisplayMessage = "Coupon Price has changed, please confirm";
                        return _response;
                    }
                }

                checkoutHeader.CartDetails = cartDto.CartDetails;
                //logic to add message to process order.
                // await _messageBus.PublishMessage(checkoutHeader, "checkoutqueue");

                ////rabbitMQ

                Payment payment = OdemeIslemi(checkoutHeader);
                _rabbitMQCartMessageSender.SendMessage(checkoutHeader, "checkoutqueue");
                EmailDto emailDto = new EmailDto();
                emailDto.Subject = "Ödeme İşlemi";
                emailDto.Body = $"Ödeme işleminiz başarıyla gerçekleşmiştir. {checkoutHeader.FirstName} {checkoutHeader.LastName} {checkoutHeader.OrderTotal}$" ;
                emailDto.To = checkoutHeader.Email;
                _emailService.SendEmail(emailDto);
                Console.WriteLine($"Ödeme işleminiz başarıyla gerçekleşmiştir. {checkoutHeader.FirstName} {checkoutHeader.LastName} {checkoutHeader.OrderTotal}$");
                await _cartRepository.ClearCart(checkoutHeader.UserId);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        public Payment OdemeIslemi(CheckoutHeaderDto checkoutHeaderDto)
        {

            CartDto cartDto = _cartRepository.GetCartByUserIdNonAsync(checkoutHeaderDto.UserId);

            Options options = new Options();

            options.ApiKey = "sandbox-0l8rAJLEGKScJKtCr1BvWCpHj1GMzFOj";
            options.SecretKey = "sandbox-3ApoMiDQOWaryOMlXeWKNkvchqJqDYQb";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = new Random().Next(1111, 9999).ToString();
            request.Price = checkoutHeaderDto.OrderTotal.ToString();
            request.PaidPrice = checkoutHeaderDto.OrderTotal.ToString();
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = checkoutHeaderDto.CartHeaderId.ToString();
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = checkoutHeaderDto.CartHeaderId.ToString();
            paymentCard.CardNumber = checkoutHeaderDto.CardNumber;
            paymentCard.ExpireMonth = checkoutHeaderDto.ExpiryMonth;
            paymentCard.ExpireYear = checkoutHeaderDto.ExpiryYear;
            paymentCard.Cvc = checkoutHeaderDto.CVV;
            paymentCard.RegisterCard = 0;
            paymentCard.CardAlias = "Inveon";
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer();
            //buyer.Id = cartDto.CartHeader.UserId;
            buyer.Id = "BY789";
            buyer.Name = checkoutHeaderDto.FirstName;
            buyer.Surname = checkoutHeaderDto.FirstName;
            buyer.GsmNumber = checkoutHeaderDto.Phone;
            buyer.Email = checkoutHeaderDto.Email;
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = checkoutHeaderDto.FirstName;
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();

            foreach (var item in checkoutHeaderDto.CartDetails)
            {
                Console.WriteLine("ITEM: " + item.Product.Name + item.Product.Price);
                BasketItem basketItem = new BasketItem();
                basketItem.Id = item.ProductId.ToString();
                basketItem.Name = item.Product.Name;
                basketItem.Category1 = item.Product.Category;
                basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                basketItem.Price = (item.Product.Price * item.Count).ToString();
                basketItems.Add(basketItem);
            }
            
            request.BasketItems = basketItems;

            return Payment.Create(request, options);
        }
    }

}
