using System.Collections.Generic;
using System;

public interface IAlertDAO {
    Guid AddAlert(DateTime time);
    DateTime GetAlert(Guid id);
}

public class AlertService	
{
    private readonly IAlertDAO storage;
    
    public AlertService(IAlertDAO item){
        storage = item;
    }
	
    public Guid RaiseAlert()
    {
        return this.storage.AddAlert(DateTime.Now);
    }
	
    public DateTime GetAlertTime(Guid id)
    {
        return this.storage.GetAlert(id);
    }	
}
	
public class AlertDAO: IAlertDAO
{
    private readonly Dictionary<Guid, DateTime> alerts = new Dictionary<Guid, DateTime>();
	
    public Guid AddAlert(DateTime time)
    {
        Guid id = Guid.NewGuid();
        this.alerts.Add(id, time);
        return id;
    }
	
    public DateTime GetAlert(Guid id)
    {
        return this.alerts[id];
    }	
}