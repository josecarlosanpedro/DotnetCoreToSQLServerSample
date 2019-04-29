using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StarterKit.Data;
using StarterKit.Models;

namespace StarterKit.Services
{
  public class SampleServices : ISampleServices
  {
    private readonly Dictionary<string, SampleItemModel> _sampleItem;
    private readonly SampleItemData _db;

    public SampleServices(SampleItemData ctx)
    {
      _db = ctx;
      _sampleItem = new Dictionary<string, SampleItemModel>();
    }
    public SampleItemModel AddSampleItems(SampleItemModel items)
    {
      _sampleItem.Add(items.SampleName, items);
      return items;
    }

    public IEnumerable<SampleItemModel> GetSampleItems()
    {
      var result = _db.Users.Select(item => new SampleItemModel
      {
        SampleTableId = item.UserId,
        SampleName = item.Name,
        Name = item.Email,
      }
      )
      .ToList();
      return result;
    }
  }
}
