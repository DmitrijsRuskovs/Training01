using System;
using System.Collections.Generic;

namespace VideoStore
{
    class VideoStore
    {
        private static List<Video> _videoList = new List<Video>();

        public VideoStore()
        { 
        }

        public void AddVideo(string title)
        {
           _videoList.Add(new Video(title));
        }
        
        public void Checkout(string title)
        {
            foreach (Video i in _videoList)
            {
                if (i.Title == title) i.BeingCheckedOut();
            }
        }

        public void ReturnVideo(string title)
        {
            foreach (Video i in _videoList)
            {
                if (i.Title == title) i.BeingReturned();
            }
        }

        public void TakeUsersRating(double rating, string title)
        {
            foreach (Video i in _videoList)
            {
                if (i.Title == title) i.ReceivingRating(rating);
            }
        }

        public void ListInventory()
        {
            foreach (Video i in _videoList)
            {
                Console.WriteLine(i.ToString());
            }

        }
    }
}
