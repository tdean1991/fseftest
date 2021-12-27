module domain.BloggingModel

open System.ComponentModel.DataAnnotations
open Microsoft.EntityFrameworkCore
open EntityFrameworkCore.FSharp.Extensions
open System
[<CLIMutable>]
type Blog = {
    [<Key>] Key: Guid
    Url: string

}



type BloggingContext() =
    inherit DbContext()

    [<DefaultValue>] val mutable blogs : DbSet<Blog>
    member this.Blogs with get() = this.blogs and set v = this.blogs <- v

    override _.OnModelCreating builder =
        builder.RegisterOptionTypes() // enables option values for all entities

    override __.OnConfiguring(options: DbContextOptionsBuilder) : unit =
        options.UseSqlServer("Data Source=DEAN-LT-TARDIS\SQLEXPRESS;Initial Catalog=efcfstest;Integrated Security=True") |> ignore

