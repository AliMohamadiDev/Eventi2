﻿using _01_EventiQuery.Contracts.Article;

namespace _01_EventiQuery.Contracts.ArticleCategory;

public class ArticleCategoryQueryModel
{
    public string Name { get; set; }
    public string? Picture { get; set; }
    public string PictureAlt { get; set; }
    public string PictureTitle { get; set; }
    public string Description { get; set; }
    public int ShowOrder { get; set; }
    public string Slug { get; set; }
    public string Keywords { get; set; }
    public List<string> KeywordList { get; set; } = new();
    public string MetaDescription { get; set; }
    public string? CanonicalAddress { get; set; }
    public long ArticlesCount { get; set; }
    public List<ArticleQueryModel> Articles { get; set; }
}