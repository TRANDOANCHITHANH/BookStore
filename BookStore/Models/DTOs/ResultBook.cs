﻿namespace BookStore.Models.DTOs
{
    // record ResultBookModel lưu thông tin sách: tên sách, tên tác giả, tổng số sách
    public record ResultBookModel(string BookName, string AuthorName, int TongSach);
    public record ResultBookViewModel(DateTime StartDate, DateTime EndDate, IEnumerable<ResultBookModel> ResultBookModels);
}
