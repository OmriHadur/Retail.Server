namespace Retail.Standard.Shared.Errors
{
    public enum BadRequestReason
    {
        SameExists = 1,
        InvalidUserOrPassword,
        InvalidToken,
        InvalidGuid,
        NoOpenCart,
        NoProductWithBarcode,
        OrderNotPending,
        InvalidToHour
    }
}