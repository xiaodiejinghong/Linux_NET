using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

/// <summary>
/// Person 实体类
/// </summary>
[PetaPoco.TableName("person")]
[PetaPoco.PrimaryKey("id")]
public class Person
{
	[PetaPoco.Column("id")]
    public int ID { get; set; }

    [PetaPoco.Column("name")]
    public string Name { get; set; }

    [PetaPoco.Column("age")]
    public int Age { get; set; }

    [PetaPoco.Column("sex")]
    public string Sex { get; set; }

}