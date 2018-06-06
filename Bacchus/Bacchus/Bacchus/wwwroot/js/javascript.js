var selectedFilter;

function filterClick(element)
{
    if (selectedFilter !== null)
    {
        selectedFilter.style.backgroundColor = "transparent";
    }
    element.style.backgroundColor = "green";
    selectedFilter = element;

    var category = element.innerHTML;

    var auctionList = document.getElementsByClassName("auctionItem");
    for (var i = 0; i < auctionList.length; i++)
    {
        auctionList[i].style.display = "block";
        if (auctionList[i].dataset.category !== category)
        {
            auctionList[i].style.display = "none";
        }
    }
}

function showAll() {
    if (selectedFilter !== null) {
        selectedFilter.style.backgroundColor = "transparent";
    }
    var element = document.getElementById("all");
    element.style.backgroundColor = "green";
    selectedFilter = element;

    var auctionList = document.getElementsByClassName("auctionItem");
    for (var i = 0; i < auctionList.length; i++) {
        auctionList[i].style.display = "block";
    }
}

function openBidWindow()
{
    
}

onload = showAll;